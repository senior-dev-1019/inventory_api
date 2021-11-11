using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PaymentPurchaseController{
         private PaymentPurchaseService _service;
         public PaymentPurchaseController (PaymentPurchaseService userService){
             _service = userService;
         }
[HttpGet]
         public ActionResult<List<PaymentPurchases>> GetPaymentPurchases()=> _service.GetPaymentPurchases();
[HttpGet("{id:length(24)}")] 
         public ActionResult<PaymentPurchases> GetPaymentPurchase(string id)=>_service.GetPaymentPurchase(id);
[HttpPost]
         public ActionResult<PaymentPurchases> PostPaymentPurchase(PaymentPurchases user)=> _service.PostPaymentPurchase(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PaymentPurchases> PutPaymentPurchase(string id, PaymentPurchases user)=> _service.PutPaymentPurchase(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PaymentPurchases> DeletePaymentPurchase(string id)=> _service.DeletePaymentPurchase(id);
     }
}