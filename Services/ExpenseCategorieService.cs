using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ExpenseCategorieService{
        private readonly IMongoCollection<ExpenseCategories> _collection;

        public ExpenseCategorieService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<ExpenseCategories>("ProjectCollection");
        }

        public List<ExpenseCategories> GetExpenseCategories()=> _collection.Find(ExpenseCategories=> true).ToList();

        public ExpenseCategories GetExpenseCategory(string id )=> _collection.Find(ExpenseCategories=> ExpenseCategories.id== id).FirstOrDefault();

        public ExpenseCategories PostExpenseCategory (ExpenseCategories expenseCategory){
            _collection.InsertOne(expenseCategory);
            return expenseCategory;
        }

        public ExpenseCategories PutExpenseCategory (string id, ExpenseCategories expenseCategory){
            _collection.ReplaceOne(expenseCategory=> expenseCategory.id == id,expenseCategory);
            return expenseCategory;                
        }

        public ExpenseCategories DeleteExpenseCategory(string id){
            var expenseCategory = _collection.Find(expenseCategory => expenseCategory.id == id).FirstOrDefault();
            _collection.DeleteOne(ExpenseCategories=> ExpenseCategories.id==id);
            return expenseCategory;
        }
    
    }
}