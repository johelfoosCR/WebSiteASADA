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

        public static Receipt Create(Measurement measurement, Contract contract, int newRead)
        {
            return new Receipt()
            {
                Measurement = measurement,
                Contract = contract,
                NewRead = newRead
            };
        }

        public Measurement Measurement { get; private set; }

        public Contract Contract { get; private set; }

        public int NewRead { get; private set; }

        public bool IsPaid { get; private set; }

        public DateTime PaidDate { get; private set; }

        public double TotalAmount { get; private set; }

        internal void CalculateTotalAmount(Contract contract, IEnumerable<Charge> charges)
        { 
            int currentRead = NewRead - contract.Meter.CurrentRead;
                
            foreach (var charge in charges)
            {
                if (charge.ChargeType.IsWaterConsume)
                {
                    if (charge.CubicMeterFrom >= currentRead && currentRead <= charge.CubicMeterTo)
                    {
                        TotalAmount += charge.Price * currentRead;
                    }
                }
                else if (charge.ChargeType.IsBaseFare) { 
                    TotalAmount += contract.DoubleBasicCharge ? charge.Price * 2 : charge.Price;
                }
                else {
                    TotalAmount += charge.Price;
                }
            }


            //int meterDiff = 0;
            //double ceroToTen = 231.0;
            //double elevenTothirty = 266.0;
            //double thirtyOneToSixty = 332.0;
            //double sixtyOneAndMore = 498;
            //double hydrantFare = 24;
            //double baseFare = 2650;

            //meterDiff = waterMeter.CurrentRead - NewRead;

            ////receipt.Items.Add(new Item("S005", "Tarifa Base", (receipt.DoubleBasicCharge.Equals("S") ? baseFare * 2 : baseFare), (receipt.DoubleBasicCharge.Equals("S") ? 2 : 1), false));
            ////receipt.Items.Add(new Item("S002", "Consumo Hidrantes", hydrantFare * meterDiff, meterDiff, false));
            //double amount = 0;


            //if (meterDiff <= 10)
            //{
            //    amount = meterDiff * ceroToTen;
            //    //receipt.Items.Add(new Item("S001", "Servicio Consumo de Agua de 0 a 10", ceroToTen, meterDiff, true));
            //}

            //if (meterDiff >= 11 && meterDiff <= 30)
            //{
            //    amount += 10 * ceroToTen;
            //    amount += (meterDiff - 10) * elevenTothirty;

            //    //receipt.Items.Add(new Item("S001", "Servicio consumo de agua de 0 a 10", ceroToTen, 10, true)); 
            //    //receipt.Items.Add(ne0w Item("S006", "Servicio consumo de agua de 11 a 30", elevenTothirty, (meterDiff - 10), true)); 
            //}

            //if (meterDiff >= 31 && meterDiff <= 60)
            //{
            //    amount += 10 * ceroToTen;
            //    amount += 20 * elevenTothirty;
            //    amount += (meterDiff - 30) * thirtyOneToSixty;

            //    //receipt.Items.Add(new Item("S001", "Servicio consumo de agua de 0 a 10", ceroToTen, 10, true));
            //    //receipt.Items.Add(new Item("S006", "Servicio consumo de agua de 11 a 30", elevenTothirty, 20, true));
            //    //receipt.Items.Add(new Item("S007", "Servicio consumo de agua de 31 a 60", thirtyOneToSixty, (meterDiff - 30), true)); 

            //}

            //if (meterDiff >= 61)
            //{
            //    amount += 10 * ceroToTen;
            //    amount += 20 * elevenTothirty;
            //    amount += 30 * thirtyOneToSixty;
            //    amount += (meterDiff - 60) * sixtyOneAndMore;
            //}

            //return 0;

        }

        internal void MarkAsPaid()
        {
            IsPaid = true;
            PaidDate = DateTime.Now;
        }
    }
}