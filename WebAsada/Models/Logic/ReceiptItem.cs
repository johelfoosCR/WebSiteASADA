using System;
using System.Collections.Generic;
using System.Linq; 
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class ReceiptItem : BaseEntity
    {
        private ReceiptItem()
        {
        }

        public static ReceiptItem Create(Receipt receipt,Charge charge, int quantity, double amount, double vatRate)
        {
            return new ReceiptItem()
            {
                Receipt = receipt,
                Description = charge.ShortDesc,
                Amount = amount,
                VatAmount = amount * (vatRate / 100),
                Quantity = quantity
            };
        }

        public Receipt Receipt { get; private set; }

        public int Quantity { get; private set; }

        public string Description { get; private set; }

        public double Amount { get; private set; }
         
        public double VatAmount { get; private set; }

        public double TotalAmount => Amount + VatAmount;
         
    }
}