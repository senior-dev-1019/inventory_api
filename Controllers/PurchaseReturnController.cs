using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PurchaseReturnController{
         private PurchaseReturnService _service;
         public PurchaseReturnController (PurchaseReturnService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PurchaseReturn>> GetPurchaseReturns()=>_service.GetPurchaseReturns();
[HttpGet("{id:length(24)}")]
         public ActionResult<PurchaseReturn> GetPurchaseReturn(string id)=>_service.GetPurchaseReturn(id);
[HttpPost]
         public ActionResult<PurchaseReturn> PostPurchaseReturn(PurchaseReturn user)=> _service.PostPurchaseReturn(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PurchaseReturn> PutPurchaseReturn(string id, PurchaseReturn user)=> _service.PutPurchaseReturn(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PurchaseReturn> DeletePurchaseReturn(string id)=> _service.DeletePurchaseReturn(id);
     }
}