using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ReceiptController : BasicViewControllerActions<Receipt>
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly ContractRepository _contractRepository;
        private readonly MeasurementRepository _measurementRepository;

        public ReceiptController(ReceiptRepository receiptRepository, ContractRepository contractRepository, MeasurementRepository measurementRepository) : base(receiptRepository)
        {
            _receiptRepository = receiptRepository;
            _contractRepository = contractRepository;
            _measurementRepository = measurementRepository;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var measurement = await _measurementRepository.GetById(id.Value);
            var receipts = await _receiptRepository.GetByMeasurement(measurement);

            var receipt = new ReceiptVM() { Measurement = new MeasurementDetailVM() { Id = measurement.Id,
                                                                                      DateFrom =  measurement.DateFrom,
                                                                                      DateTo = measurement.DateTo,
                                                                                      MaxPaymentDate = measurement.MaxPaymentDate,
                                                                                      Month = measurement.Month,
                                                                                      Year = measurement.Year}, 
                                            Receipts = receipts };

            ViewData["ContractCollection"] = new SelectList(_contractRepository.GetValidData(), "Value", "Text");
            return View(receipt);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiptVM receiptVM)
        {
            var measurement = await _measurementRepository.GetById(receiptVM.Measurement.Id);
            var contract = await _contractRepository.GetById(receiptVM.Contract.Id);  
            await _receiptRepository.Save(Receipt.Create(measurement, contract, receiptVM.NewRead)); 
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
