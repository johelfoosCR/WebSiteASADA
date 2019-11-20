using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class MeasurementsController : BasicViewControllerActions<Measurement>
    {
        private readonly MeasurementRepository _measurementRepository;
        private readonly MonthRepository _monthRepository;

        private const string ATTRIBUTES_TO_BIND = "Year,ReadDate,DateFrom,DateTo,MaxPaymentDate,MessageOfTheMonth,PaymentPlace,ReadUserId,MonthId,Month";

        public MeasurementsController(MeasurementRepository measurementRepository,MonthRepository monthRepository) : base(measurementRepository) {
            _measurementRepository = measurementRepository;
            _monthRepository = monthRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<MeasurementVM>();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<MeasurementVM>(id);

        public IActionResult Create() => GetView(RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] MeasurementVM measurementVM) => await ConfirmSave(measurementVM, RefreshCollections);
         
        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<MeasurementVM>(id, RefreshCollections); 
              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] MeasurementVM measurementVM) => await ConfirmEdit(id, measurementVM, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<MeasurementVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);
         
        private void RefreshCollections()
        {
            ViewData["RegisterUserId"] = new SelectList(_measurementRepository.GetUsers(), "Id", "UserName");
            ViewData["UpdateUserId"] = new SelectList(_measurementRepository.GetUsers(), "Id", "UserName");
            ViewData["ReadUserId"] = new SelectList(_measurementRepository.GetUsers(), "Id", "UserName");
            ViewData["MonthId"] = new SelectList(_monthRepository.GetAll().Result, "Id", "ShortDesc"); 
        }
    }
}
