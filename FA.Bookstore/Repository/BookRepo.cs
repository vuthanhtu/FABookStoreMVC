using FA.Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.Bookstore.Repository
{
    public class BookRepo
    {
        private BookStoreContext bookStoreContext = new BookStoreContext();
        public Book FindBook(int bookId)
        {
            var book = bookStoreContext.Books.Where(x=>x.BookId == bookId).FirstOrDefault();    
            return book;
        }
        public bool AddBook(Book book)
        {
            bookStoreContext.Books.Add(book);
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges()!=0;
        }
        public bool DeleteBook(int bookId)
        {
            var book = bookStoreContext.Books.Where(x=>x.BookId==bookId).FirstOrDefault();
            if (book != null)
            {
                bookStoreContext.Books.Remove(book);
                bookStoreContext.SaveChanges();
                return bookStoreContext.SaveChanges() != 0;
            }
            return false;
        }
        public bool UpdateBook(int bookId, Book update)
        {
            var book = bookStoreContext.Books.Where(x => x.BookId == bookId).FirstOrDefault();
            if (book != null)
            {
                book.Title = update.Title;
                book.AuthorId = update.AuthorId;    
                book.Summary = update.Summary;
                book.ImgUrl = update.ImgUrl;
                book.Price = update.Price;
                book.Quantity = update.Quantity;
                book.CreatedDate = update.CreatedDate;
                book.ModifiedDate = update.ModifiedDate;
                book.IsActive = update.IsActive;
            }
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges()!=0;
        }
        public IEnumerable<Book> GetAllBook()
        {
            return bookStoreContext.Books.ToList();
        }
        public IEnumerable<Book> GetBookByTitle(string title)
        {
            IEnumerable<Book> books = bookStoreContext.Books.Where(x => x.Title.Equals(title));
            return books;
        }
        public IEnumerable<Book> GetBookBySummary(string summary)
        {
            IEnumerable<Book> books = bookStoreContext.Books.Where(x => x.Summary.Equals(summary));
            return books;
        }
        public Book GetLastestBook(int size)
        {
            return new Book();
        }
        public IEnumerable<Book> GetBookByMonth(DateTime monthYear)
        {
            IEnumerable<Book> books = bookStoreContext.Books.Where(x => x.CreatedDate.Month == monthYear.Month);
            return books;
        }
        public int CountBookForCategory(string category) {
            return bookStoreContext.Books.Count(x => x.Category.CateName.Equals(category));
        }
        public IEnumerable<Book> GetBookByCategory(string category)
        {
            var books = from x in bookStoreContext.Books where x.Category.CateName.Equals(category) select x;
            return books.ToList();
        }
        public int CountBookForPublisher(string publisher)
        {
            return bookStoreContext.Books.Count(x => x.Publisher.Name.Equals(publisher));
        }
        public IEnumerable<Book> GetBookByPublisher(string publisher)
        {
            var books = from x in bookStoreContext.Books where x.Publisher.Name.Equals(publisher) select x;
            return books.ToList();
        }
    }
}