using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PaymentPurchaseReturnController{
         private PaymentPurchaseReturnService _service;
         public PaymentPurchaseReturnController (PaymentPurchaseReturnService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PaymentPurchaseReturns>> GetPaymentPurchaseReturns()=>_service.GetPaymentPurchaseReturns();
[HttpGet("{id:length(24)}")]
         public ActionResult<PaymentPurchaseReturns> GetPaymentPurchaseReturn(string id)=>_service.GetPaymentPurchaseReturn(id);
[HttpPost]
         public ActionResult<PaymentPurchaseReturns> PostPaymentPurchaseReturn(PaymentPurchaseReturns user)=> _service.PostPaymentPurchaseReturn(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PaymentPurchaseReturns> PutPaymentPurchaseReturn(string id, PaymentPurchaseReturns user)=> _service.PutPaymentPurchaseReturn(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PaymentPurchaseReturns> DeletePaymentPurchaseReturn(string id)=> _service.DeletePaymentPurchaseReturn(id);
     }
}