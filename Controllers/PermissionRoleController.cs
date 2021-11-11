using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PermissionRoleController{
         private PermissionRoleService _userService;
         public PermissionRoleController (PermissionRoleService userService){
             _userService = userService;
         }
[HttpGet]
         public ActionResult<List<PermissionRole>> GetPermissionRoles()=>_userService.GetPermissionRoles();
[HttpGet("{id:length(24)}")]
         public ActionResult<PermissionRole> GetPermissionRole(string id)=>_userService.GetPermissionRole(id);
[HttpPost]
         public ActionResult<PermissionRole> PostPermissionRole(PermissionRole user)=> _userService.PostPermissionRole(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<PermissionRole> PutPermissionRole(string id, PermissionRole user)=> _userService.PutPermissionRole(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PermissionRole> DeletePermissionRole(string id)=> _userService.DeletePermissionRole(id);
     }
}