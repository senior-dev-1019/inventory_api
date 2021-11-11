using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ExpenseService{
        private readonly IMongoCollection<Expense> _collection;

        public ExpenseService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Expense>("ProjectCollection");
        }

        public List<Expense> GetExpenses()=> _collection.Find(Expense=> true).ToList();

        public Expense GetExpense(string id )=> _collection.Find(Expense=> Expense.id== id).FirstOrDefault();

        public Expense PostExpense (Expense expense){
            _collection.InsertOne(expense);
            return expense;
        }

        public Expense PutExpense (string id, Expense expense){
            _collection.ReplaceOne(expense=> expense.id == id,expense);
            return expense;                
        }

        public Expense DeleteExpense(string id){
            var expense = _collection.Find(expense => expense.id == id).FirstOrDefault();
            _collection.DeleteOne(Expense=> Expense.id==id);
            return expense;
        }
    
    }
}