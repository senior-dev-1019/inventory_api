using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class AdjustmentController{
         private AdjustmentService _service;
         public AdjustmentController (AdjustmentService service){
             _service = service;
         }
        [HttpGet]
         public ActionResult<List<Adjustments>> GetAdjustmentss()=>_service.GetAdjustments();
        [HttpGet("{id:length(24)}")]
         public ActionResult<Adjustments> GetAdjustments(string id)=>_service.GetAdjustment(id);
        [HttpPost]
         public ActionResult<Adjustments> PostAdjustments(Adjustments adjustmentDetails)=> _service.PostAdjustments(adjustmentDetails);
        [HttpPut("{id:length(24)}")]
         public ActionResult<Adjustments> PutAdjustments(string id, Adjustments adjustmentDetails)=> _service.PutAdjustments(id,adjustmentDetails);
        [HttpDelete("{id:length(24)}")]
         public ActionResult<Adjustments> DeleteAdjustments(string id)=> _service.DeleteAdjustments(id);
     }
}