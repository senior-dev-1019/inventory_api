using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class UnitController{
         private UnitService _service;
         public UnitController (UnitService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Units>> GetUnits()=>_service.GetUnits();
[HttpGet("{id:length(24)}")]
         public ActionResult<Units> GetUnit(string id)=>_service.GetUnit(id);
[HttpPost]
         public ActionResult<Units> PostUnit(Units user)=> _service.PostUnit(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Units> PutUnit(string id, Units user)=> _service.PutUnit(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Units> DeleteUnit(string id)=> _service.DeleteUnit(id);
     }
}