using System;
using System.Text;
using WebAsada.Models;
using WebAsada.Repository;
using System.Net.Http;
using System.Collections.Generic;
using StringTokenFormatter;
using WebAsada.ViewModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Services
{
    public class MeasurementService
    {
        private readonly MeasurementRepository _measurementRepository;
        public MeasurementService(MeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository; 
        }

        public async Task<byte[]> GenerateMeasurementFile(Measurement measurement, IEnumerable<ReceiptVM> receipts, HttpClient qrCodeClient, HttpClient pdfClient) 
        { 
            StringBuilder completeHtml = new StringBuilder(); 
            var htmlBaseContent = System.IO.File.ReadAllText("Templates/BaseReceiptTemplate.html");
            var htmlTemplate = System.IO.File.ReadAllText("Templates/ReceiptTemplate.html");
            var htmlDetailTemplate = System.IO.File.ReadAllText("Templates/DetailReceiptTemplate.html");
            var ImageBytes = System.IO.File.ReadAllBytes("Images/LOGO.png");
               
            foreach (var receipt in receipts)
            {
                StringBuilder builderDetail = new StringBuilder();
                foreach (var item in receipt.Items)
                {
                    builderDetail.Append(htmlDetailTemplate.FormatToken(item));
                }

                HttpRequestMessage requestQr = new HttpRequestMessage(HttpMethod.Post, qrCodeClient.BaseAddress);
                var qrCode = await(await qrCodeClient.PostAsJsonAsync(qrCodeClient.BaseAddress, receipt.ReceiptCode)).Content.ReadAsByteArrayAsync();

                StringBuilder builderMeasurement = new StringBuilder();
                builderMeasurement.Append(htmlTemplate.FormatToken(new
                {
                    MeterNumber = receipt.MeterSerialNumber,
                    ReceiptNumber = receipt.ReceiptCode,
                    CustomerName = receipt.FullName.ToUpper(),
                    IdentificationNumber = receipt.IdentificatioNumber,
                    MaxPaymentDate = measurement.MaxPaymentDate.ToString("dddd dd 'de' MMMM 'de' yyyy"),
                    receipt.LastRead,
                    receipt.CurrentRead,
                    base64ImageLogo = Convert.ToBase64String(ImageBytes),
                    base64QrCode = Convert.ToBase64String(qrCode),
                    TotalCubicMeterConsume = receipt.CubicMetersConsume,
                    TotalAmount = receipt.TotalAmount.ToString("0.##"),
                    measurement.PaymentPlace,
                    measurement.MessageOfTheMonth,
                    DetailReceipt = builderDetail.ToString()
                }));

                completeHtml.Append(builderMeasurement.ToString());
            }
             
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, pdfClient.BaseAddress)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    FileName = $"{measurement.Month}-{measurement.Year}",
                    DocumentTitle = "Lectura de Agua",
                    Content = htmlBaseContent.FormatToken(new { Content = completeHtml.ToString() }),
                    GetContentFromUrl = false
                }), Encoding.UTF8, "application/json")
            };

            return await(await pdfClient.SendAsync(request)).Content.ReadAsByteArrayAsync();
        }
    }
}
