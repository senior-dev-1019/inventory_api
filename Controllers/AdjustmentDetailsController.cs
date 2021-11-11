using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class AdjustmentDetailsController{
         private AdjustmentDetailsService _service;
         public AdjustmentDetailsController (AdjustmentDetailsService service){
             _service = service;
         }
        [HttpGet]
         public ActionResult<List<AdjustmentDetails>> GetAdjustmentDetailss()=>_service.GetAdjustmentDetails();
        [HttpGet("{id:length(24)}")]
         public ActionResult<AdjustmentDetails> GetAdjustmentDetails(string id)=>_service.GetAdjustmentDetail(id);
        [HttpPost]
         public ActionResult<AdjustmentDetails> PostAdjustmentDetails(AdjustmentDetails adjustmentDetails)=> _service.PostAdjustmentDetails(adjustmentDetails);
        [HttpPut("{id:length(24)}")]
         public ActionResult<AdjustmentDetails> PutAdjustmentDetails(string id, AdjustmentDetails adjustmentDetails)=> _service.PutAdjustmentDetails(id,adjustmentDetails);
        [HttpDelete("{id:length(24)}")]
         public ActionResult<AdjustmentDetails> DeleteAdjustmentDetails(string id)=> _service.DeleteAdjustmentDetails(id);
     }
}