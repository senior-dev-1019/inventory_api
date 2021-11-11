using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class oAuthRefreshTokenController{
         private oAuthRefreshTokenService _service;
         public oAuthRefreshTokenController (oAuthRefreshTokenService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<oAuthRefreshTokens>> GetoAuthRefreshTokens()=>_service.GetoAuthRefreshTokens();
[HttpGet("{id:length(24)}")]
         public ActionResult<oAuthRefreshTokens> GetoAuthRefreshToken(string id)=>_service.GetoAuthRefreshToken(id);
[HttpPost]
         public ActionResult<oAuthRefreshTokens> PostoAuthRefreshToken(oAuthRefreshTokens user)=> _service.PostoAuthRefreshToken(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<oAuthRefreshTokens> PutoAuthRefreshToken(string id, oAuthRefreshTokens user)=> _service.PutoAuthRefreshToken(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<oAuthRefreshTokens> DeleteoAuthRefreshToken(string id)=> _service.DeleteoAuthRefreshToken(id);
     }
}