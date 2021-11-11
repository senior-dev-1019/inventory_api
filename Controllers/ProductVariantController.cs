using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ProductVariantController{
         private ProductVariantService _service;
         public ProductVariantController (ProductVariantService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<ProductVariants>> GetProductVariants()=>_service.GetProductVariants();
[HttpGet("{id:length(24)}")]
         public ActionResult<ProductVariants> GetProductVariant(string id)=>_service.GetProductVariant(id);
[HttpPost]
         public ActionResult<ProductVariants> PostProductVariant(ProductVariants user)=> _service.PostProductVariant(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<ProductVariants> PutProductVariant(string id, ProductVariants user)=> _service.PutProductVariant(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<ProductVariants> DeleteProductVariant(string id)=> _service.DeleteProductVariant(id);
     }
}