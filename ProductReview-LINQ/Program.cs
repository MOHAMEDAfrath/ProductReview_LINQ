using System;
using System.Collections.Generic;

namespace ProductReview_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<ReviewProduct> productreview = ProductReviewManagement.GetProductReviewList();
            ProductReviewManagement.RetrieveRecordsBasedOnRatingAndProductId(productreview);
        }
    } 
}
