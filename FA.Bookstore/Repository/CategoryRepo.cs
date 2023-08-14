using FA.Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace FA.Bookstore.Repository
{
    public class CategoryRepo
    {
        private BookStoreContext bookStoreContext = new BookStoreContext();
        public bool AddCategory(Category category)
        {
            bookStoreContext.Categories.Add(category);
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges()!=0 ;
        }
        public IEnumerable<Category> GetAllCategories() {
            return bookStoreContext.Categories.ToList();
        }
        public Category Find(int categoryId)
        {
            var category = bookStoreContext.Categories.Where(c=>c.CateId == categoryId).FirstOrDefault();
            return category;
        }
        public bool DeleteCategory(int categoryId)
        {
            var category = bookStoreContext.Categories.Where(c => c.CateId == categoryId).FirstOrDefault();
            if(category!= null)
            {
                bookStoreContext.Categories.Remove(category);
                bookStoreContext.SaveChanges();
                return bookStoreContext.SaveChanges() != 0;
            }
            return false;
        }
        public bool UpdateCategory(int categoryId, Category update)
        {
            var category = bookStoreContext.Categories.Where(c => c.CateId == categoryId).FirstOrDefault();
            if(category != null)
            {
                category.CateName = update.CateName;
                category.Description = update.Description;
            }
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges() != 0;
        }
    }
}