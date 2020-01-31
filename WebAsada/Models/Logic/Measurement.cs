using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Measurement : BaseEntity
    {
        public Month Month { get; private set; }
        public int MonthId { get; private set; } 
        public int Year { get; private set; }
        public SystemUser ReadUser { get; private set; }
        public string ReadUserId { get; private set; }
        public DateTime ReadDate { get; private set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public DateTime MaxPaymentDate { get; private set; }
        public string MessageOfTheMonth { get; private set; }
        public string PaymentPlace { get; private set; }
        public bool IsActive { get; private set; }         
        [NotMapped]
        public bool HasPaymentReceipts { get; private set; }

        public void SetHasPaymentReceipts() {
            HasPaymentReceipts = true;
        }
        public void Activate()
        {
            IsActive = true;
        }

        internal static Measurement SincronizeObject(Measurement currentMeasurement, Measurement newMeasurement)
        { 
            currentMeasurement.MessageOfTheMonth = newMeasurement.MessageOfTheMonth;
            currentMeasurement.MaxPaymentDate = newMeasurement.MaxPaymentDate;
            currentMeasurement.PaymentPlace = newMeasurement.PaymentPlace;
            currentMeasurement.ReadDate = newMeasurement.ReadDate;
            currentMeasurement.ReadUserId = newMeasurement.ReadUserId;
            currentMeasurement.DateFrom = newMeasurement.DateFrom;
            currentMeasurement.DateTo = newMeasurement.DateTo;
            currentMeasurement.MonthId = newMeasurement.MonthId;
            return currentMeasurement;
        }
         
    }
}
