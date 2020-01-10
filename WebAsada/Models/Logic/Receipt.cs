using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Receipt : BaseEntity
    {
        private Receipt()
        {
        }

        public static Receipt Create(int measurementId, int contractId,int lastRead, int newRead)
        {
            return new Receipt()
            {
                MeasurementId = measurementId,
                ContractId = contractId,
                LastRead = lastRead,
                NewRead = newRead,
                Items = new List<ReceiptItem>()
            };
        }

        public Measurement Measurement { get; private set; }

        public int MeasurementId { get; private set; }

        public Contract Contract { get; private set; }

        public int ContractId { get; private set; }

        public int LastRead { get; private set; }

        public int NewRead { get; private set; }

        public bool IsPaid { get; private set; }

        public DateTime PaidDate { get; private set; }

        public double TotalAmount { get; private set; }

        public List<ReceiptItem> Items { get; private set; }

        internal void CalculateTotalAmount(Contract contract, IEnumerable<Charge> charges)
        {
            int currentRead = NewRead - contract.Meter.CurrentRead; 
            Maybe<ChargeType> chargeType = charges.Select(x => x.ChargeType).FirstOrDefault(x => x.IsVATCharge && x.IsWaterConsume);
            var shouldChargeVAT = chargeType.HasValue && (currentRead > 30);
            var vatRate = shouldChargeVAT ? chargeType.Value.VatRate : 0D;
            double waterConsumeAmount = 0D;
            var lineAmount = 0D;

            foreach (var charge in charges)
            {
                if (charge.ChargeType.IsWaterConsume)
                {
                    if (currentRead < charge.CubicMeterFrom)
                        continue;

                    var valueToSubstract = (currentRead > charge.CubicMeterTo) ? charge.CubicMeterTo : currentRead;
                    var quantity = (int)(valueToSubstract - (charge.CubicMeterFrom - 1));
                    lineAmount = (charge.Price * quantity);
                    Items.Add(ReceiptItem.Create(this, charge, quantity, lineAmount, vatRate));
                    waterConsumeAmount += lineAmount;
                }
                else if (charge.ChargeType.IsBaseFare)
                {
                    lineAmount = contract.DoubleBasicCharge ? charge.Price * 2 : charge.Price;
                    Items.Add(ReceiptItem.Create(this, charge, contract.DoubleBasicCharge ? 2 : 1, lineAmount, 0));
                    TotalAmount += lineAmount;
                }
                else
                {
                    lineAmount = charge.Price * currentRead;
                    Items.Add(ReceiptItem.Create(this, charge, currentRead, lineAmount, 0));
                    TotalAmount += lineAmount;
                }
            }

            if (currentRead > 0)
            {
                TotalAmount += (shouldChargeVAT) ? waterConsumeAmount + (waterConsumeAmount * (vatRate/100)) : waterConsumeAmount;
            }
        }

        internal void MarkAsPaid()
        {
            IsPaid = true;
            PaidDate = DateTime.Now;
            Contract.Meter.SetCurrentRead(NewRead);
        }
    }
}