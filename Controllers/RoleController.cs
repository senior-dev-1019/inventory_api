using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class RoleController{
         private RoleService _service;
         public RoleController (RoleService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Roles>> GetRoles()=>_service.GetRoles();
[HttpGet("{id:length(24)}")]
         public ActionResult<Roles> GetRole(string id)=>_service.GetRole(id);
[HttpPost]
         public ActionResult<Roles> PostRole(Roles user)=> _service.PostRole(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Roles> PutRole(string id, Roles user)=> _service.PutRole(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Roles> DeleteRole(string id)=> _service.DeleteRole(id);
     }
}