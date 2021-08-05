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
            productreview = ProjectReviewManagement.GetProductReviewList();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
