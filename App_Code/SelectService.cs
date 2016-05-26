using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SelectService" in code, svc and config file together.
public class SelectService : ISelectService
{
    BookReviewDbEntities brde = new BookReviewDbEntities();
    public List<string> GetAuthors()
    {
        List<string> authors = new List<string>();

        var auth = from a in brde.Authors
                   select new { a.AuthorName };
        foreach (var v in auth)
        {
            authors.Add(v.AuthorName.ToString());
        }
        return authors;
    }

    public List<string> GetBooks()
    {
        List<string> books = new List<string>();

        var bks = from b in brde.Books
                  select new { b.BookTitle };
        foreach (var v in bks)
        {
            books.Add(v.BookTitle.ToString());
        }
        return books;
    }

    public List<string> GetCategories()
    {
        List<string> categories = new List<string>();

        var cats = from c in brde.Categories
                   select new { c.CategoryName };
        foreach (var v in cats)
        {
            categories.Add(v.CategoryName.ToString());
        }
        return categories;
    }

    public List<ReviewInfo> GetGetReviewsByReviewer(string reviewerName)
    {
        List<ReviewInfo> reviews = new List<ReviewInfo>();

        var revs = from r in brde.Reviews
                   where r.Reviewer.ReviewerLastName.Equals(reviewerName)
                   select new
                   {
                       r.Book.BookTitle,
                       r.Reviewer.ReviewerLastName,
                       r.ReviewTitle,
                       r.ReviewDate,
                       r.ReviewRating,
                       r.ReviewText
                   };
        foreach(var v in revs)
        {
            ReviewInfo info = new ReviewInfo();
            info.BookTitle = v.BookTitle;
            info.ReviewTitle = v.ReviewTitle;
            info.ReviewerName = v.ReviewerLastName;
            info.ReviewDate = v.ReviewDate;
            info.BookRating = v.ReviewRating;
            info.ReviewBody = v.ReviewText;
            reviews.Add(info);
        }

        return reviews;
    }

    public List<string> GetReviewers()
    {
        List<string> reviewers = new List<string>();

        var rev = from r in brde.Reviewers
                  select new { r.ReviewerLastName };
        foreach (var v in rev)
        {
            reviewers.Add(v.ReviewerLastName.ToString());
        }
        return reviewers;
    }

    public List<ReviewInfo> GetReviewsByAuthor(string authorName)
    {
        List<ReviewInfo> reviews = new List<ReviewInfo>();

        var revs = from r in brde.Reviews
                   from a in r.Book.Authors
                   where a.AuthorName.Equals(authorName)
                   select new
                   {
                       r.Book.BookTitle,
                       r.Reviewer.ReviewerLastName,
                       r.ReviewTitle,
                       r.ReviewDate,
                       r.ReviewRating,
                       r.ReviewText
                   };

        foreach (var v in revs)
        {
            ReviewInfo info = new ReviewInfo();
            info.BookTitle = v.BookTitle;
            info.ReviewTitle = v.ReviewTitle;
            info.ReviewerName = v.ReviewerLastName;
            info.ReviewDate = v.ReviewDate;
            info.BookRating = v.ReviewRating;
            info.ReviewBody = v.ReviewText;
            reviews.Add(info);
        }

        return reviews;
    }

    public List<ReviewInfo> GetReviewsByCategory(string categoryName)
    {
        List<ReviewInfo> reviews = new List<ReviewInfo>();

        var revs = from r in brde.Reviews
                   from a in r.Book.Categories
                   where a.CategoryName.Equals(categoryName)
                   select new
                   {
                       r.Book.BookTitle,
                       r.Reviewer.ReviewerLastName,
                       r.ReviewTitle,
                       r.ReviewDate,
                       r.ReviewRating,
                       r.ReviewText
                   };

        foreach (var v in revs)
        {
            ReviewInfo info = new ReviewInfo();
            info.BookTitle = v.BookTitle;
            info.ReviewTitle = v.ReviewTitle;
            info.ReviewerName = v.ReviewerLastName;
            info.ReviewDate = v.ReviewDate;
            info.BookRating = v.ReviewRating;
            info.ReviewBody = v.ReviewText;
            reviews.Add(info);
        }

        return reviews;
    }

    
}
