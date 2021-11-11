using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class oAuthPersonalAccessClientController{
         private oAuthPersonalAccessClientService _service;
         public oAuthPersonalAccessClientController (oAuthPersonalAccessClientService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<oAuthPersonalAccessClients>> GetoAuthPersonalAccessClients()=>_service.GetoAuthPersonalAccessClients();
[HttpGet("{id:length(24)}")]
         public ActionResult<oAuthPersonalAccessClients> GetoAuthPersonalAccessClient(string id)=>_service.GetoAuthPersonalAccessClient(id);
[HttpPost]
         public ActionResult<oAuthPersonalAccessClients> PostoAuthPersonalAccessClient(oAuthPersonalAccessClients user)=> _service.PostoAuthPersonalAccessClient(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<oAuthPersonalAccessClients> PutoAuthPersonalAccessClient(string id, oAuthPersonalAccessClients user)=> _service.PutoAuthPersonalAccessClient(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<oAuthPersonalAccessClients> DeleteoAuthPersonalAccessClient(string id)=> _service.DeleteoAuthPersonalAccessClient(id);
     }
}