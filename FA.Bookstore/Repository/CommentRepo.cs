using FA.Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FA.Bookstore.Repository
{
    public class CommentRepo
    {
        private BookStoreContext bookStoreContext = new BookStoreContext();
        public Comment Find(int commentId)
        {
            var comment = bookStoreContext.Comments.Where(x=>x.CommentId == commentId).FirstOrDefault();
            return comment;
        }
        public bool AddComment(Comment comment)
        {
            bookStoreContext.Comments.Add(comment);
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges() != 0 ;

        }
        public bool DeleteComment(int commentId) 
        {
            var comment = bookStoreContext.Comments.Where(x => x.CommentId == commentId).FirstOrDefault();
            if(comment != null)
            {
                bookStoreContext.Comments.Remove(comment);
                bookStoreContext.SaveChanges();
                return bookStoreContext.SaveChanges() != 0;
            }
            return false;
        }
        public bool UpdateComment(int  commentId, Comment update)
        {
            var comment = bookStoreContext.Comments.Where(x => x.CommentId == commentId).FirstOrDefault();
            if (comment!=null)
            {
                comment.Content = update.Content;
                comment.CreateDat = update.CreateDat;
                comment.IsActive = update.IsActive;
            }
            bookStoreContext.SaveChanges();
            return bookStoreContext.SaveChanges()!=0;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            return bookStoreContext.Comments.ToList();
        }
        public IEnumerable<Comment> GetCommentByBook(int bookId)
        {
            var comments = from x in bookStoreContext.Comments where x.BookId == bookId select x;
            return comments.ToList();
        }
    }
}