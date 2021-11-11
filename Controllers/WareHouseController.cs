using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class WareHouseController{
         private WareHouseService _service;
         public WareHouseController (WareHouseService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<WareHouses>> GetWareHouses()=>_service.GetWareHouses();
[HttpGet("{id:length(24)}")]
         public ActionResult<WareHouses> GetWareHouse(string id)=>_service.GetWareHouse(id);
[HttpPost]
         public ActionResult<WareHouses> PostWareHouse(WareHouses user)=> _service.PostWareHouse(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<WareHouses> PutWareHouse(string id, WareHouses user)=> _service.PutWareHouse(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<WareHouses> DeleteWareHouse(string id)=> _service.DeleteWareHouse(id);
     }
}