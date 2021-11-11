using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PurchaseDetailController{
         private PurchaseDetailService _service;
         public PurchaseDetailController (PurchaseDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PurchaseDetails>> GetPurchaseDetails()=>_service.GetPurchaseDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<PurchaseDetails> GetPurchaseDetail(string id)=>_service.GetPurchaseDetail(id);
[HttpPost]
         public ActionResult<PurchaseDetails> PostPurchaseDetail(PurchaseDetails user)=> _service.PostPurchaseDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PurchaseDetails> PutPurchaseDetail(string id, PurchaseDetails user)=> _service.PutPurchaseDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PurchaseDetails> DeletePurchaseDetail(string id)=> _service.DeletePurchaseDetail(id);
     }
}