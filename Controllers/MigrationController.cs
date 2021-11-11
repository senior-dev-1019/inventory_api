using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class MigrationController{
         private MigrationService _service;
         public MigrationController (MigrationService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Migrations>> GetMigrations()=>_service.GetMigrations();
[HttpGet("{id:length(24)}")]
         public ActionResult<Migrations> GetMigration(string id)=>_service.GetMigration(id);
[HttpPost]
         public ActionResult<Migrations> PostMigration(Migrations migration)=> _service.PostMigration(migration);
[HttpPut("{id:length(24)}")]
         public ActionResult<Migrations> PutMigration(string id, Migrations migration)=> _service.PutMigration(id,migration);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Migrations> DeleteMigration(string id)=> _service.DeleteMigration(id);
     }
}