using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISelectService" in both code and config file together.
[ServiceContract]
public interface ISelectService
{
    [OperationContract]
    List<string> GetBooks();

    [OperationContract]
    List<string> GetAuthors();

    [OperationContract]
    List<string> GetReviewers();

    [OperationContract]
    List<string> GetCategories();

    [OperationContract]
    List<ReviewInfo> GetReviewsByCategory(string categoryName);

    [OperationContract]
    List<ReviewInfo> GetReviewsByAuthor(string authorName);

    [OperationContract]
    List<ReviewInfo> GetGetReviewsByReviewer(string reviewerName);
    
}

[DataContract]
public class ReviewInfo
{
    [DataMember]
    public string BookTitle { set; get; }

    [DataMember]
    public string ReviewTitle { set; get; }

    [DataMember]
    public string ReviewerName { set; get; }

    [DataMember]
    public DateTime ReviewDate { set; get; }

    [DataMember]
    public int BookRating { set; get; }

    [DataMember]
    public string ReviewBody { set; get; }

}



