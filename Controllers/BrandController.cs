using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class BrandController{
         private BrandService _service;
         public BrandController (BrandService service){
             _service = service;
         }
        [HttpGet]
         public ActionResult<List<Brands>> GetBrands()=>_service.GetBrands();
        [HttpGet("{id:length(24)}")]
         public ActionResult<Brands> GetBrand(string id)=>_service.GetBrand(id);
        [HttpPost]
         public ActionResult<Brands> PostBrand(Brands brand)=> _service.PostBrand(brand);
        [HttpPut("{id:length(24)}")]
         public ActionResult<Brands> PutBrand(string id, Brands brand)=> _service.PutBrand(id,brand);
        [HttpDelete("{id:length(24)}")]
         public ActionResult<Brands> DeleteBrand(string id)=> _service.DeleteBrand(id);
     }
}