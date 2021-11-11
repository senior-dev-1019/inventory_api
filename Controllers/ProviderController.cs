using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ProviderController{
         private ProvidersService _service;
         public ProviderController (ProvidersService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Providers>> GetProviders()=>_service.GetProviders();
[HttpGet("{id:length(24)}")]
         public ActionResult<Providers> GetProvider(string id)=>_service.GetProvider(id);
[HttpPost]
         public ActionResult<Providers> PostProvider(Providers user)=> _service.PostProvider(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Providers> PutProvider(string id, Providers user)=> _service.PutProvider(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Providers> DeleteProvider(string id)=> _service.DeleteProvider(id);
     }
}