using FA.Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.Bookstore.Repository
{
    public class PublisherRepo
    {
        private BookStoreContext bookStoreContext = new BookStoreContext();
        public bool AddPublisher(Publisher publisher)
        {
            bookStoreContext.Publishers.Add(publisher);
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges() !=0;

        }
        public IEnumerable<Publisher> GetAllPublisher() 
        {
            return bookStoreContext.Publishers.ToList();
        }
        public Publisher Find(int publisherId) 
        {
            var publisher = bookStoreContext.Publishers.Where(c=>c.PubId == publisherId).FirstOrDefault();
            return publisher;
        }
        public bool DeletePublisher(int publisherId)
        {
            var publisher = bookStoreContext.Publishers.Where(c => c.PubId == publisherId).FirstOrDefault();
            if(publisher != null)
            {
                bookStoreContext.Publishers.Remove(publisher);
                bookStoreContext.SaveChanges();
                return bookStoreContext.SaveChanges() != 0;
            }
            return false;
        }
        public bool UpdatePublisher(int publisherId,Publisher update)
        {
            var publisher = bookStoreContext.Publishers.Where(c => c.PubId == publisherId).FirstOrDefault();
            if(publisher != null)
            {
                publisher.Name = update.Name;
                publisher.Description = update.Description;
            }
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges() != 0;
        }
    }
}