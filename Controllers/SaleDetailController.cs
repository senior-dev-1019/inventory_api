using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class SaleDetailController{
         private SaleDetailService _service;
         public SaleDetailController (SaleDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<SaleDetails>> GetSaleDetails()=>_service.GetSaleDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<SaleDetails> GetSaleDetail(string id)=>_service.GetSaleDetail(id);
[HttpPost]
         public ActionResult<SaleDetails> PostSaleDetail(SaleDetails user)=> _service.PostSaleDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<SaleDetails> PutSaleDetail(string id, SaleDetails user)=> _service.PutSaleDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<SaleDetails> DeleteSaleDetail(string id)=> _service.DeleteSaleDetail(id);
     }
}