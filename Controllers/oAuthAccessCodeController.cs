using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class oAuthAccessCodeController{
         private oAuthAccessCodeService _service;
         public oAuthAccessCodeController (oAuthAccessCodeService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<oAuthAccessTokens>> GetoAuthAccessTokens()=>_service.GetoAuthAccessTokens();
[HttpGet("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> GetoAuthAccessToken(string id)=>_service.GetoAuthAccessToken(id);
[HttpPost]
         public ActionResult<oAuthAccessTokens> PostoAuthAccessToken(oAuthAccessTokens user)=> _service.PostoAuthAccessToken(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> PutoAuthAccessToken(string id, oAuthAccessTokens user)=> _service.PutoAuthAccessToken(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> DeleteoAuthAccessToken(string id)=> _service.DeleteoAuthAccessToken(id);
     }
}