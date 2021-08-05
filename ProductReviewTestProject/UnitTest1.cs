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
            int[] temp = { 1, 7, 2 };
            var expected = new List<int>(temp);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
