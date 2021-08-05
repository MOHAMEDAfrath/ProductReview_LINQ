using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductReview_LINQ;
using System.Collections.Generic;

namespace ProductReviewTestProject
{
  
    [TestClass]
    public class UnitTest1
    {
        List<ReviewProduct> productreview;
        [TestInitialize]
        public void SetUp()
        {
            productreview = ProductReviewManagement.GetProductReviewList();
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
    }
}
