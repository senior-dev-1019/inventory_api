using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class SaleReturnDetailController{
         private SaleReturnDetailService _service;
         public SaleReturnDetailController (SaleReturnDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<SaleReturnDetails>> GetSaleReturnDetails()=>_service.GetSaleReturnDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<SaleReturnDetails> GetSaleReturnDetail(string id)=>_service.GetSaleReturnDetail(id);
[HttpPost]
         public ActionResult<SaleReturnDetails> PostSaleReturnDetail(SaleReturnDetails user)=> _service.PostSaleReturnDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<SaleReturnDetails> PutSaleReturnDetail(string id, SaleReturnDetails user)=> _service.PutSaleReturnDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<SaleReturnDetails> DeleteSaleReturnDetail(string id)=> _service.DeleteSaleReturnDetail(id);
     }
}