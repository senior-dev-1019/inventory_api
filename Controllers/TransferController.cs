using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class TransferController{
         private TransferService _service;
         public TransferController (TransferService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Transfers>> GetTransfers()=>_service.GetTransfers();
[HttpGet("{id:length(24)}")]
         public ActionResult<Transfers> GetTransfer(string id)=>_service.GetTransfer(id);
[HttpPost]
         public ActionResult<Transfers> PostTransfer(Transfers user)=> _service.PostTransfer(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Transfers> PutTransfer(string id, Transfers user)=> _service.PutTransfer(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Transfers> DeleteTransfer(string id)=> _service.DeleteTransfer(id);
     }
}