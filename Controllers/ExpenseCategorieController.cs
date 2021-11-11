using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ExpenseCategorieController{
         private ExpenseCategorieService _service;
         public ExpenseCategorieController (ExpenseCategorieService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<ExpenseCategories>> GetExpenseCategories()=>_service.GetExpenseCategories();
[HttpGet("{id:length(24)}")]
         public ActionResult<ExpenseCategories> GetExpenseCategory(string id)=>_service.GetExpenseCategory(id);
[HttpPost]
         public ActionResult<ExpenseCategories> PostExpenseCategory(ExpenseCategories user)=> _service.PostExpenseCategory(user);
[HttpPut("{id:length(24)}")]
         public ActionResult<ExpenseCategories> PutExpenseCategory(string id, ExpenseCategories user)=> _service.PutExpenseCategory(id,user);
[HttpDelete("{id:length(24)}")]
         public ActionResult<ExpenseCategories> DeleteExpenseCategory(string id)=> _service.DeleteExpenseCategory(id);
     }
}