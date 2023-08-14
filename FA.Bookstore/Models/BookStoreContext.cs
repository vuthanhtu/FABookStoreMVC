using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.Bookstore.Models
{
    public class BookStoreContext : DbContext
    {
        // Your context has been configured to use a 'BookStoreContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FA.Bookstore.Models.BookStoreContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookStoreContext' 
        // connection string in the application configuration file.
        public BookStoreContext()
            : base("name=BookStoreContext")
        {
            //Database.SetInitializer<BookStoreContext>(new CreateDatabaseIfNotExists<BookStoreContext>());
            Database.SetInitializer(new Initializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
    public class Initializer : CreateDatabaseIfNotExists<BookStoreContext>
    {
        protected override void Seed(BookStoreContext bookStoreContext)
        {
            IList<Category> categories = new List<Category>();
            categories.Add(new Category { CateId = 1, CateName = "Romantic", Description = "Category 1" });
            categories.Add(new Category { CateId = 2, CateName = "Comic", Description = "Category 2" });
            categories.Add(new Category { CateId = 3, CateName = "Novel", Description = "Category 3" });

            IList<Publisher> publishers = new List<Publisher>();
            publishers.Add(new Publisher { PubId = 1, Name = "NXB Kim Dong", Description = "publisher 1" });
            publishers.Add(new Publisher { PubId = 2, Name = "NXB Tuoi tre", Description = "publisher 2" });
            publishers.Add(new Publisher { PubId = 3, Name = "NXB Tay Nam", Description = "publisher 3" });

            bookStoreContext.Categories.AddRange(categories);
            bookStoreContext.Publishers.AddRange(publishers);
            bookStoreContext.SaveChanges();

            IList<Book> books = new List<Book>();
            books.Add(new Book()
            {
                BookId = 1,
                Title = "Conan",
                AuthorId = 1,
                Summary = "Conana hay",
                ImgUrl = "url1",
                Price = 5000,
                Quantity = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                CateId = 1,
                PubId = 1
            });
            books.Add(new Book()
            {
                BookId = 2,
                Title = "Doraemon",
                AuthorId = 2,
                Summary = "Doramon2 hay",
                ImgUrl = "url2",
                Price = 50000,
                Quantity = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,

                CateId = 2,
                PubId = 2
            });
            books.Add(new Book()
            {
                BookId = 3,
                Title = "Conan3",
                AuthorId = 1,
                Summary = "3 hay",
                ImgUrl = "url3",
                Price = 5000,
                Quantity = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                CateId = 3,
                PubId = 3
            });

            bookStoreContext.Books.AddRange(books);
            bookStoreContext.SaveChanges();
            base.Seed(bookStoreContext);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}