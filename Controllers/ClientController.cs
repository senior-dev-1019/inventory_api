using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ClientController{
         private ClientService _service;
         public ClientController (ClientService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Clients>> GetClients()=>_service.GetClients();
[HttpGet("{id:length(24)}")]
         public ActionResult<Clients> GetClient(string id)=>_service.GetClient(id);
[HttpPost]
         public ActionResult<Clients> PostClient(Clients user)=> _service.PostClient(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Clients> PutClient(string id, Clients user)=> _service.PutClient(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Clients> DeleteClient(string id)=> _service.DeleteClient(id);
     }
}