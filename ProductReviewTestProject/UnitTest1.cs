using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductReview_LINQ;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewTestProject
{
  
    [TestClass]
    public class UnitTest1
    {
        List<ReviewProduct> productreview;
        DataTable dataTable;
        [TestInitialize]
        public void SetUp()
        {
            productreview = ProductReviewManagement.GetProductReviewList();
            dataTable = ProductDataTable.CreateDataTable(productreview);
        }
        //retrieves top three record is tested
        [TestMethod]
        public void TestMethodForRetrieveTopThreeRecord()
        {
            List<int> actual = ProductReviewManagement.RetrieveTopThreeRating(productreview);
            int[] temp = { 1, 7, 11 };
            var expected = new List<int>(temp);
            CollectionAssert.AreEqual(expected, actual);
        }
        //retrieves based on productid and rating
        [TestMethod]
        public void TestMethodForRetrieveBasedonProductIdandRating()
        {
            List<string> actual = ProductReviewManagement.RetrieveRecordsBasedOnRatingAndProductId(productreview);
            string[] temp = {"1 1 Nice 5 True","4 7 Nice 5 True","4 4 Average 4 True"};
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(expected, actual);
        }
        //retrieve count based on product id
        [TestMethod]
        public void TestMethodForCountBasedOnProductId()
        {
            string expected = "1 3 2 4 3 4 4 3 9 3 5 2 7 1 10 3 11 2 ";
            string actual = ProductReviewManagement.RetrieveCountForProductID(productreview);
            Assert.AreEqual(expected, actual);
        }
        //test for retrieved records only for product id and review
        [TestMethod]
        public void TestMethodForRetrievingProductIdandReview()
        {
            string expected = "1 Nice 2 Very Good 3 Nice 2 Bad 1 Very Good 2 Average 4 Nice 9 Average 3 Bad 5 Average 7 Very Good 9 Very Good 10 Bad 1 Bad 5 Average 3 Nice 10 Bad 9 Very Good 10 Bad 11 Very Good 2 Nice 4 Nice 11 Average 3 Bad 4 Average ";
            string actual = ProductReviewManagement.RetrieveOnlyProductIdAndReviews(productreview);
            Assert.AreEqual(expected, actual);
        }
        //test method for skip top 5 records
        [TestMethod]
        public void TestMethodForSkipTop5Records()
        {
            List<int> actual = ProductReviewManagement.SkipTopFiveRecords(productreview);
            int[] temp = { 4 ,9 ,4 ,3, 3, 9, 2, 11, 1, 7, 4, 1, 6, 8, 10, 5, 2, 9, 6, 8 };
            var expected = new List<int>(temp);
            CollectionAssert.AreEqual(expected, actual);
        }
        //test method retrieve data if islike is true
        [TestMethod]
        public void TestMethodForRetrievalDataBasedOnIsLike()
        {
            List<int> actual = ProductDataTable.ReturnsOnlyIsLikeFieldAsTrue(dataTable);
            int[] temp = {1,2,4,1,6,7,8,4,10,5,9,11,11,1,6,7,8,4};
            var expected = new List<int>(temp);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
