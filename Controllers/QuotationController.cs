using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class QuotationController{
         private QuotationService _service;
         public QuotationController (QuotationService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Quotations>> GetQuotations()=>_service.GetQuotations();
[HttpGet("{id:length(24)}")]
         public ActionResult<Quotations> GetQuotation(string id)=>_service.GetQuotation(id);
[HttpPost]
         public ActionResult<Quotations> PostQuotation(Quotations user)=> _service.PostQuotation(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Quotations> PutQuotation(string id, Quotations user)=> _service.PutQuotation(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Quotations> DeleteQuotation(string id)=> _service.DeleteQuotation(id);
     }
}