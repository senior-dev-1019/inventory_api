using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class CurrencieController{
         private CurrencieService _service;
         public CurrencieController (CurrencieService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Currencies>> GetCurrencies()=>_service.GetCurrencies();
[HttpGet("{id:length(24)}")]
         public ActionResult<Currencies> GetCurrency(string id)=>_service.GetCurrency(id);
[HttpPost]
         public ActionResult<Currencies> PostCurrency(Currencies user)=> _service.PostCurrency(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Currencies> PutCurrency(string id, Currencies user)=> _service.PutCurrency(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Currencies> DeleteCurrency(string id)=> _service.DeleteCurrency(id);
     }
}