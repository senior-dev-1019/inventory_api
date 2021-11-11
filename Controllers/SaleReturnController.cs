using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class SaleReturnController{
         private SaleReturnService _service;
         public SaleReturnController (SaleReturnService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<SaleReturns>> GetSaleReturns()=>_service.GetSaleReturns();
[HttpGet("{id:length(24)}")]
         public ActionResult<SaleReturns> GetSaleReturn(string id)=>_service.GetSaleReturn(id);
[HttpPost]
         public ActionResult<SaleReturns> PostSaleReturn(SaleReturns user)=> _service.PostSaleReturn(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<SaleReturns> PutSaleReturn(string id, SaleReturns user)=> _service.PutSaleReturn(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<SaleReturns> DeleteSaleReturn(string id)=> _service.DeleteSaleReturn(id);
     }
}