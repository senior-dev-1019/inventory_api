using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PurchaseController{
         private PurchaseService _service;
         public PurchaseController (PurchaseService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Purchases>> GetPurchases()=>_service.GetPurchases();
[HttpGet("{id:length(24)}")]
         public ActionResult<Purchases> GetPurchase(string id)=>_service.GetPurchase(id);
[HttpPost]
         public ActionResult<Purchases> PostPurchase(Purchases user)=> _service.PostPurchase(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Purchases> PutPurchase(string id, Purchases user)=> _service.PutPurchase(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Purchases> DeletePurchase(string id)=> _service.DeletePurchase(id);
     }
}