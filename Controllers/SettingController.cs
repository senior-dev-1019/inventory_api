using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class SettingController{
         private SettingService _service;
         public SettingController (SettingService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Settings>> GetSettings()=>_service.GetSettings();
[HttpGet("{id:length(24)}")]
         public ActionResult<Settings> GetSetting(string id)=>_service.GetSetting(id);
[HttpPost]
         public ActionResult<Settings> PostSetting(Settings user)=> _service.PostSetting(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Settings> PutSetting(string id, Settings user)=> _service.PutSetting(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Settings> DeleteSetting(string id)=> _service.DeleteSetting(id);
     }
}