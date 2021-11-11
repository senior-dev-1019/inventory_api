using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class RoleUserController{
         private RoleUserService _service;
         public RoleUserController (RoleUserService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<RoleUser>> GetRoleUsers()=>_service.GetRoleUsers();
[HttpGet("{id:length(24)}")]
         public ActionResult<RoleUser> GetRoleUser(string id)=>_service.GetRoleUser(id);
[HttpPost]
         public ActionResult<RoleUser> PostRoleUser(RoleUser user)=> _service.PostRoleUser(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<RoleUser> PutRoleUser(string id, RoleUser user)=> _service.PutRoleUser(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<RoleUser> DeleteRoleUser(string id)=> _service.DeleteRoleUser(id);
     }
}