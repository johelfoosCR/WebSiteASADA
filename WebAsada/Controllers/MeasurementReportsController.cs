using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Repository;
using StringTokenFormatter; 
using WebAsada.ViewModels;
using WebAsada.BaseObjects;
using System.Text;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace WebAsada.Controllers
{
    public class MeasurementReportsController : BaseController
    {
        private readonly MonthRepository _monthRepository;
        private readonly ReceiptRepository _receiptRepository;
        private readonly MeasurementRepository _measurementRepository;
        private readonly IHttpClientFactory _clientFactory;

        public MeasurementReportsController(MonthRepository monthRepository, ReceiptRepository receiptRepository, MeasurementRepository measurementRepository, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _monthRepository = monthRepository;
            _receiptRepository = receiptRepository;
            _measurementRepository = measurementRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["MonthCollection"] = new SelectList(await _monthRepository.GetAll(), "Nemotecnico", "ShortDesc");
            return View();
        }

        public async Task<FileResult> GenerateReceipts(MeasurementReportVM measurementReport)
        {
            var measurement = await _measurementRepository.GetByMonthAndYear(measurementReport.MonthNemotecnico, measurementReport.Year); 
            if (measurement.HasNoValue)
                return (FileResult)ErrorContent("sdad");

            var Receipts = await _receiptRepository.GetReceiptDetailsByMeasurement(measurement.Value.Id);

            StringBuilder completeHtml = new StringBuilder();

            var htmlBaseContent = System.IO.File.ReadAllText("Templates/BaseReceiptTemplate.html");
            var htmlTemplate = System.IO.File.ReadAllText("Templates/ReceiptTemplate.html");
            var htmlDetailTemplate = System.IO.File.ReadAllText("Templates/DetailReceiptTemplate.html");
            var ImageBytes = System.IO.File.ReadAllBytes("Images/LOGO.png");

            var clientQr = _clientFactory.CreateClient("QrGeneratorApi"); 

            foreach (var receipt in Receipts)
            {
                StringBuilder builderDetail = new StringBuilder(); 
                foreach (var item in receipt.Items) {
                   builderDetail.Append(htmlDetailTemplate.FormatToken(item));
                }

                HttpRequestMessage requestQr = new HttpRequestMessage(HttpMethod.Post, clientQr.BaseAddress);
                var qrCode = await (await clientQr.PostAsJsonAsync(clientQr.BaseAddress, receipt.ReceiptCode)).Content.ReadAsByteArrayAsync();
                 
                StringBuilder builderMeasurement = new StringBuilder(); 
                builderMeasurement.Append(htmlTemplate.FormatToken(new {
                    MeterNumber =  receipt.MeterSerialNumber,
                    ReceiptNumber = receipt.ReceiptCode,
                    CustomerName = receipt.FullName.ToUpper(),
                    IdentificationNumber = receipt.IdentificatioNumber,
                    MaxPaymentDate = measurement.Value.MaxPaymentDate.ToString("dddd dd 'de' MMMM 'de' yyyy"),
                    receipt.LastRead,
                    receipt.CurrentRead,
                    base64ImageLogo = "dsfsf",
                    base64QrCode = Convert.ToBase64String(qrCode),
                    TotalCubicMeterConsume =  receipt.CubicMetersConsume,
                    TotalAmount = receipt.TotalAmount.ToString("0.##"),
                    measurement.Value.PaymentPlace,
                    measurement.Value.MessageOfTheMonth,
                    DetailReceipt = builderDetail.ToString()
                }));

                completeHtml.Append(builderMeasurement.ToString());
            }

            var clientPdf = _clientFactory.CreateClient("PdfGeneratorApi");  
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, clientPdf.BaseAddress);
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                FileName = $"{measurement.Value.Month}-{measurement.Value.Year}",
                DocumentTitle = "Lectura de Agua",
                Content = htmlBaseContent.FormatToken(new { Content = completeHtml.ToString()}) ,
                GetContentFromUrl = false
            }), Encoding.UTF8, "application/json");

            var daraaa = (await clientPdf.SendAsync(request)).Content.ReadAsByteArrayAsync().Result;

            var RESULT = await (await clientPdf.PostAsJsonAsync(clientPdf.BaseAddress, request)).Content.ReadAsByteArrayAsync();
 

            return File(RESULT, "application/pdf", $"{measurement.Value.Month.Nemotecnico}-{measurement.Value.Year}.pdf"); 
        }
    }
}