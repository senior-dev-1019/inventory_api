using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PaymentSaleReturnController{
         private PaymentSaleReturnService _service;
         public PaymentSaleReturnController (PaymentSaleReturnService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PaymentSaleReturns>> GetPaymentSaleReturns()=>_service.GetPaymentSaleReturns();
[HttpGet("{id:length(24)}")]
         public ActionResult<PaymentSaleReturns> GetPaymentSaleReturn(string id)=>_service.GetPaymentSaleReturn(id);
[HttpPost]
         public ActionResult<PaymentSaleReturns> PostPaymentSaleReturn(PaymentSaleReturns user)=> _service.PostPaymentSaleReturn(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PaymentSaleReturns> PutPaymentSaleReturn(string id, PaymentSaleReturns user)=> _service.PutPaymentSaleReturn(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PaymentSaleReturns> DeletePaymentSaleReturn(string id)=> _service.DeletePaymentSaleReturn(id);
     }
}