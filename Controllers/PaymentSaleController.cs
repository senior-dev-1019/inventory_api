using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PaymentSaleController{
         private PaymentSaleService _service;
         public PaymentSaleController (PaymentSaleService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PaymentSales>> GetPaymentSales()=>_service.GetPaymentSales();
[HttpGet("{id:length(24)}")]
         public ActionResult<PaymentSales> GetPaymentSale(string id)=>_service.GetPaymentSale(id);
[HttpPost]
         public ActionResult<PaymentSales> PostPaymentSale(PaymentSales user)=> _service.PostPaymentSale(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PaymentSales> PutPaymentSale(string id, PaymentSales user)=> _service.PutPaymentSale(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PaymentSales> DeletePaymentSale(string id)=> _service.DeletePaymentSale(id);
     }
}