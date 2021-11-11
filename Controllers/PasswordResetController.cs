using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class PasswordResetController{
         private PasswordResetService _service;
         public PasswordResetController (PasswordResetService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<PasswordResets>> GetPasswordResets()=>_service.GetPasswordResets();
[HttpGet("{id:length(24)}")]
         public ActionResult<PasswordResets> GetPasswordReset(string id)=>_service.GetPasswordReset(id);
[HttpPost]
         public ActionResult<PasswordResets> PostPasswordReset(PasswordResets PasswordResets)=> _service.PostPasswordReset(PasswordResets);
[HttpPut("{id:length(24)}")]
         public ActionResult<PasswordResets> PutPasswordReset(string id, PasswordResets PasswordResets)=> _service.PutPasswordReset(id,PasswordResets);
[HttpDelete("{id:length(24)}")]
         public ActionResult<PasswordResets> DeletePasswordReset(string id)=> _service.DeletePasswordReset(id);
     }
}