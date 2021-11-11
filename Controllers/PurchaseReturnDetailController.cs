using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PurchaseReturnDetailController{
         private PurchaseReturnDetailService _service;
         public PurchaseReturnDetailController (PurchaseReturnDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PurchaseReturnDetails>> GetPurchaseReturnDetails()=>_service.GetPurchaseReturnDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<PurchaseReturnDetails> GetPurchaseReturnDetail(string id)=>_service.GetPurchaseReturnDetail(id);
[HttpPost]
         public ActionResult<PurchaseReturnDetails> PostPurchaseReturnDetail(PurchaseReturnDetails user)=> _service.PostPurchaseReturnDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PurchaseReturnDetails> PutPurchaseReturnDetail(string id, PurchaseReturnDetails user)=> _service.PutPurchaseReturnDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PurchaseReturnDetails> DeletePurchaseReturnDetail(string id)=> _service.DeletePurchaseReturnDetail(id);
     }
}