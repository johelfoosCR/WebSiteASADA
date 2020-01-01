using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly ContractRepository _contractRepository;
        private readonly MeasurementRepository _measurementRepository;
        private readonly ChargeRepository _chargeRepository;

        public ReceiptController(ReceiptRepository receiptRepository, 
                                 ContractRepository contractRepository, 
                                 MeasurementRepository measurementRepository,
                                 ChargeRepository chargeRepository)
        {
            _receiptRepository = receiptRepository;
            _contractRepository = contractRepository;
            _measurementRepository = measurementRepository;
            _chargeRepository = chargeRepository;
        }

        public async Task<IActionResult> ReceiptByMeasurement(int? id)
        {
            var measurement = await _measurementRepository.GetById(id.Value); 
            var receipt = new ReceiptVM()
            {
                Measurement = new MeasurementDetailVM()
                {
                    Id = measurement.Id,
                    DateFrom = measurement.DateFrom,
                    DateTo = measurement.DateTo,
                    MaxPaymentDate = measurement.MaxPaymentDate,
                    Month = measurement.Month,
                    Year = measurement.Year
                },
                Receipts = await _receiptRepository.GetByMeasurement(measurement)
            };

            ViewData["ContractCollection"] = new SelectList(_contractRepository.GetValidData(), "Value", "Text");
            return View(receipt); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptVM receiptVM)
        { 
            var contract = await _contractRepository.GetById(receiptVM.Contract.Id); 
            var receipt = Receipt.Create(receiptVM.Measurement.Id, receiptVM.Contract.Id, receiptVM.NewRead);   
            var chargeList = await _chargeRepository.GetValidChargeActive();  
            receipt.CalculateTotalAmount(contract, chargeList);

            await _receiptRepository.Save(receipt);
            return Ok();
        }
         
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return NotFound(); 
            await _receiptRepository.Delete(id.Value); 
            return Ok();
        }

    }
}
