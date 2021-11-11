using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ServerController{
         private ServerService _service;
         public ServerController (ServerService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Servers>> GetServers()=>_service.GetServers();
[HttpGet("{id:length(24)}")]
         public ActionResult<Servers> GetServer(string id)=>_service.GetServer(id);
[HttpPost]
         public ActionResult<Servers> PostServer(Servers user)=> _service.PostServer(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Servers> PutServer(string id, Servers user)=> _service.PutServer(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Servers> DeleteServer(string id)=> _service.DeleteServer(id);
     }
}