using Swagger.Models;
using Swagger.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swagger.Controller{
     [ApiController]
     [Route("[controller]")]
     public class ExpenseController{
         private ExpenseService _service;
         public ExpenseController (ExpenseService service){
             _service = service;
         }
[HttpGet]
         public ActionResult<List<Expense>> GetExpenses()=>_service.GetExpenses();
[HttpGet("{id:length(24)}")]
         public ActionResult<Expense> GetExpense(string id)=>_service.GetExpense(id);
[HttpPost]
         public ActionResult<Expense> PostExpense(Expense expense)=> _service.PostExpense(expense);
[HttpPut("{id:length(24)}")]
         public ActionResult<Expense> PutExpense(string id, Expense expense)=> _service.PutExpense(id,expense);
[HttpDelete("{id:length(24)}")]
         public ActionResult<Expense> DeleteExpense(string id)=> _service.DeleteExpense(id);
     }
}