using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class SaleController{
         private SaleService _service;
         public SaleController (SaleService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Sales>> GetSales()=>_service.GetSales();
[HttpGet("{id:length(24)}")]
         public ActionResult<Sales> GetSale(string id)=>_service.GetSale(id);
[HttpPost]
         public ActionResult<Sales> PostSale(Sales user)=> _service.PostSale(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<Sales> PutSale(string id, Sales user)=> _service.PutSale(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Sales> DeleteSale(string id)=> _service.DeleteSale(id);
     }
}