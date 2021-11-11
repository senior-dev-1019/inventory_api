using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class UserController{
         private UserService _userService;
         public UserController (UserService userService){
             _userService = userService;
         }
[HttpGet]
         public ActionResult<List<User>> GetUsers()=>_userService.GetUsers();
[HttpGet("{id:length(24)}")]
         public ActionResult<User> GetUser(string id)=>_userService.GetUser(id);
[HttpPost]
         public ActionResult<User> PostUser(User user)=> _userService.PostUser(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<User> PutUser(string id, User user)=> _userService.PutUser(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<User> DeleteUser(string id)=> _userService.DeleteUser(id);
     }
}