using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ProductWareHouseController{
         private ProductWareHouseService _service;
         public ProductWareHouseController (ProductWareHouseService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<ProductWareHouse>> GetProductWareHouses()=>_service.GetProductWareHouses();
[HttpGet("{id:length(24)}")]
         public ActionResult<ProductWareHouse> GetProductWareHouse(string id)=>_service.GetProductWareHouse(id);
[HttpPost]
         public ActionResult<ProductWareHouse> PostProductWareHouse(ProductWareHouse user)=> _service.PostProductWareHouse(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<ProductWareHouse> PutProductWareHouse(string id, ProductWareHouse user)=> _service.PutProductWareHouse(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<ProductWareHouse> DeleteProductWareHouse(string id)=> _service.DeleteProductWareHouse(id);
     }
}