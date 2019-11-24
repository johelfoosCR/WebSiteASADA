using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class WaterMeter: BaseEntity
    {
        public string Model { get; private set; }

        [Required]
        public string SerialNumber { get; private set; } 

        [Required]
        public DateTime BougthDate { get; private set; }

        [Required]
        public int SupplierId { get; private set; }

        [Required]
        [DefaultValue(0)]
        public int CurrentRead { get; private set; }

        public Supplier Supplier { get; private set; }

        [Required]
        public bool IsActive { get; private set; }

        public string Comments { get; private set; }

        internal static WaterMeter SincronizeObject(WaterMeter currentObject, WaterMeter newObject)
        {
            currentObject.BougthDate = newObject.BougthDate;
            currentObject.Comments = newObject.Comments; 
            currentObject.IsActive = newObject.IsActive;
            currentObject.Model = newObject.Model;
            currentObject.SerialNumber = newObject.SerialNumber;
            currentObject.SupplierId = newObject.SupplierId;
            return currentObject;
        }

        // falta actualizar valor actual al registrar medidor o leerlo al momento de iniciar
        internal void AddWaterConsume(int waterConsume)
        {
            CurrentRead =+ waterConsume;
        }
    }
}
