using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class CategoryController{
         private CategoryService _service;
         public CategoryController (CategoryService service){
             _service = service;
         }
        [HttpGet]
         public ActionResult<List<Categories>> GetCategories()=>_service.GetCategories();
        [HttpGet("{id:length(24)}")]
         public ActionResult<Categories> GetCategory(string id)=>_service.GetCategory(id);
        [HttpPost]
         public ActionResult<Categories> PostCategory(Categories Categories)=> _service.PostCategory(Categories);
        [HttpPut("{id:length(24)}")]
         public ActionResult<Categories> PutCategory(string id, Categories Categories)=> _service.PutCategory(id,Categories);
        [HttpDelete("{id:length(24)}")]
         public ActionResult<Categories> DeleteCategory(string id)=> _service.DeleteCategory(id);
     }
}