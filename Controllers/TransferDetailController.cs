using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class TransferDetailController{
         private TransferDetailService _service;
         public TransferDetailController (TransferDetailService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<TransferDetails>> GetTransferDetails()=>_service.GetTransferDetails();
[HttpGet("{id:length(24)}")]
         public ActionResult<TransferDetails> GetTransferDetail(string id)=>_service.GetTransferDetail(id);
[HttpPost]
         public ActionResult<TransferDetails> PostTransferDetail(TransferDetails user)=> _service.PostTransferDetail(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<TransferDetails> PutTransferDetail(string id, TransferDetails user)=> _service.PutTransferDetail(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<TransferDetails> DeleteTransferDetail(string id)=> _service.DeleteTransferDetail(id);
     }
}