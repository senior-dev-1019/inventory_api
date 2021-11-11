using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class RelationalSchemaController{
         private RelationalSchemaService _service;
         public RelationalSchemaController (RelationalSchemaService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<RelationalSchema>> GetRelationalSchemas()=>_service.GetRelationalSchemas();
[HttpGet("{id:length(24)}")]
         public ActionResult<RelationalSchema> GetRelationalSchema(string id)=>_service.GetRelationalSchema(id);
[HttpPost]
         public ActionResult<RelationalSchema> PostRelationalSchema(RelationalSchema user)=> _service.PostRelationalSchema(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<RelationalSchema> PutRelationalSchema(string id, RelationalSchema user)=> _service.PutRelationalSchema(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<RelationalSchema> DeleteRelationalSchema(string id)=> _service.DeleteRelationalSchema(id);
     }
}