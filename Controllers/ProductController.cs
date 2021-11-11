using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ProductController{
         private ProductService _service;
         public ProductController (ProductService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Products>> GetProducts()=>_service.GetProducts();
[HttpGet("{id:length(24)}")]
         public ActionResult<Products> GetProduct(string id)=>_service.GetProduct(id);
[HttpPost]
         public ActionResult<Products> PostProduct(Products user)=> _service.PostProduct(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Products> PutProduct(string id, Products user)=> _service.PutProduct(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Products> DeleteProduct(string id)=> _service.DeleteProduct(id);
     }
}