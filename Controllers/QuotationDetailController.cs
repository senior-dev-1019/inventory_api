using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class QuotationDetailController{
         private QuotationDetailService _service;
         public QuotationDetailController (QuotationDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<QuotationDetails>> GetQuotationDetails()=>_service.GetQuotationDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<QuotationDetails> GetQuotationDetail(string id)=>_service.GetQuotationDetail(id);
[HttpPost]
         public ActionResult<QuotationDetails> PostQuotationDetail(QuotationDetails user)=> _service.PostQuotationDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<QuotationDetails> PutQuotationDetail(string id, QuotationDetails user)=> _service.PutQuotationDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<QuotationDetails> DeleteQuotationDetail(string id)=> _service.DeleteQuotationDetail(id);
     }
}