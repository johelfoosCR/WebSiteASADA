using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class MeasurementsController : BasicViewControllerActions<Measurement>
    {
         private readonly MonthRepository _monthRepository;
        private readonly SystemUserRepository _systemUserRepository;
        private readonly MeasurementRepository _measurementRepository;

        private const string ATTRIBUTES_TO_BIND = "Year,ReadDate,DateFrom,DateTo,MaxPaymentDate,MessageOfTheMonth,PaymentPlace,ReadUserId,MonthId,Month";

        public MeasurementsController(MeasurementRepository measurementRepository, MonthRepository monthRepository, SystemUserRepository systemUserRepository) : base(measurementRepository) {
             _monthRepository = monthRepository;
            _systemUserRepository = systemUserRepository;
            _measurementRepository = measurementRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<MeasurementVM>();

        public async Task<IActionResult> Create() {
            await RefreshCollectionsAsync();
            return View(new MeasurementVM() { Year = DateTime.Now.Year,
                                              MonthId = DateTime.Now.Month,
                                              ReadDate = DateTime.Now,
                                              DateFrom = DateTime.Now, 
                                              DateTo = DateTime.Now.AddDays(30), 
                                              MaxPaymentDate = DateTime.Now.AddDays(5) }) ;
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] MeasurementVM measurementVM) => await ConfirmSave(measurementVM, RefreshCollectionsAsync);
         
        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<MeasurementVM>(id,  RefreshCollectionsAsync);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] MeasurementVM measurementVM)
        {
            return await ConfirmEdit(id, measurementVM, RefreshCollectionsAsync);
        }

        [HttpPost]
        public async Task<IActionResult> Activate(int? id)
        {
            if (!id.HasValue) return NotFound();

            var result = await _measurementRepository.ActivateMeasurement(id.Value);

            if (result.IsFailure)
                return ErrorContent(result.Error);

            return Ok();
        }

        private async Task RefreshCollectionsAsync()
        { 
            ViewData["ReadUserId"] = new SelectList(await _systemUserRepository.GetAll(), "Id", "FullName");
            ViewData["MonthId"] = new SelectList(await _monthRepository.GetAll(), "Id", "ShortDesc"); 
        }
    }
}
