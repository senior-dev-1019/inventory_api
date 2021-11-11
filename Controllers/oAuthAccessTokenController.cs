using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class oAuthAccessTokenController{
         private oAuthAccessTokenService _service;
         public oAuthAccessTokenController (oAuthAccessTokenService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<oAuthAccessTokens>> GetoAuthAccessTokens()=>_service.GetoAuthAccessTokens();
[HttpGet("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> GetoAuthAccessToken(string id)=>_service.GetoAuthAccessToken(id);
[HttpPost]
         public ActionResult<oAuthAccessTokens> PostoAuthAccessToken(oAuthAccessTokens oAuthAccessToken)=> _service.PostoAuthAccessToken(oAuthAccessToken);
[HttpPut("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> PutoAuthAccessToken(string id, oAuthAccessTokens oAuthAccessToken)=> _service.PutoAuthAccessToken(id,oAuthAccessToken);
[HttpDelete("{id:length(24)}")]
         public ActionResult<oAuthAccessTokens> DeleteoAuthAccessToken(string id)=> _service.DeleteoAuthAccessToken(id);
     }
}