using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReview_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<ReviewProduct> productreview = ProductReviewManagement.GetProductReviewList();
            DataTable dataTable = ProductDataTable.CreateDataTable(productreview);
            ProductDataTable.ReturnsReviewForNice(dataTable);

                   }
    } 
}
