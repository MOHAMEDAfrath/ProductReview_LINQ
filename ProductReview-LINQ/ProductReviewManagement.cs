using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview_LINQ
{
    public class ProductReviewManagement
    {
        //Add details to list
        public static List<ReviewProduct> GetProductReviewList()
        {
            List<ReviewProduct> products = new List<ReviewProduct>();
            products.Add(new ReviewProduct() { productId = 1, userId = 1, review = "Nice", rating = 5, isLike = true });
            products.Add(new ReviewProduct() { productId = 2, userId = 2, review = "Very Good", rating = 2, isLike = true });
            products.Add(new ReviewProduct() { productId = 3, userId = 4, review = "Nice", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 2, userId = 5, review = "Bad", rating = 4, isLike = false });
            products.Add(new ReviewProduct() { productId = 1, userId = 1, review = "Very Good", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 2, userId = 6, review = "Average", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 4, userId = 7, review = "Nice", rating = 5, isLike = true });
            products.Add(new ReviewProduct() { productId = 9, userId = 8, review = "Average", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 3, userId = 9, review = "Bad", rating = 3, isLike = false });
            products.Add(new ReviewProduct() { productId = 5, userId = 4, review = "Average", rating = 3, isLike = true });
            products.Add(new ReviewProduct() { productId = 7, userId = 10, review = "Very Good", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 9, userId = 5, review = "Very Good", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 10, userId = 3, review = "Bad", rating = 3, isLike = false });
            products.Add(new ReviewProduct() { productId = 1, userId = 2, review = "Bad", rating = 1, isLike = false });
            products.Add(new ReviewProduct() { productId = 5, userId = 9, review = "Average", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 3, userId = 11, review = "Nice", rating = 5, isLike = true });
            products.Add(new ReviewProduct() { productId = 10, userId = 3, review = "Bad", rating = 3, isLike = false });
            products.Add(new ReviewProduct() { productId = 9, userId = 11, review = "Very Good", rating = 2, isLike = true });
            products.Add(new ReviewProduct() { productId = 10, userId = 9, review = "Bad", rating = 5, isLike = false });
            products.Add(new ReviewProduct() { productId = 11, userId = 1, review = "Very Good", rating = 2, isLike = true });
            products.Add(new ReviewProduct() { productId = 2, userId = 6, review = "Nice", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 4, userId = 7, review = "Nice", rating = 2, isLike = true });
            products.Add(new ReviewProduct() { productId = 11, userId = 8, review = "Average", rating = 1, isLike = true });
            products.Add(new ReviewProduct() { productId = 3, userId = 9, review = "Bad", rating = 3, isLike = false });
            products.Add(new ReviewProduct() { productId = 4, userId = 4, review = "Average", rating = 4, isLike = true });
            //DisplayList(products);
            return products ;
        }
        //Retrieve top three records
        public static List<int> RetrieveTopThreeRating(List<ReviewProduct> products)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Top Three Records Based On Rating");
            var result = (from product in products orderby product.rating descending select product).Take(3).ToList();
            DisplayList(result);
            foreach(var mem in result)
            {
                list.Add(mem.userId);
            }
            return list;
        }
        //retrieve records based on rating and product ID
        public static List<string> RetrieveRecordsBasedOnRatingAndProductId(List<ReviewProduct> products)
        {
            List<string> list = new List<string>();   
            var result = (from product in products where product.rating > 3 && (product.productId == 1 || product.productId == 4 || product.productId == 9) select product).ToList();
            DisplayList(result);
            foreach(var mem in result)
            {
                list.Add(mem.productId + " " + mem.userId + " " + mem.review + " " + mem.rating + " " + mem.isLike);
            }
            return list;
        }
        //retrieve count
        public static string RetrieveCountForProductID(List<ReviewProduct> products)
        {
            string update= null;
            var result = products.GroupBy(x => x.productId).Select(a => new { ProductId = a.Key, count = a.Count() });
            foreach (var mem in result)
            {
                Console.WriteLine("ProductId"+" "+ mem.ProductId + " " + "Count" + " "+ mem.count);

                update += mem.ProductId + " " + mem.count+" ";
               
            }
            return update;
        }
        //Retrieve productId and reviews only
        public static string RetrieveOnlyProductIdAndReviews(List<ReviewProduct> products)
        {
            string update = null;
            var result = products.Select(product => new { ProductId = product.productId, Review = product.review }).ToList();
            foreach (var mem in result)
            {
                Console.WriteLine(mem.ProductId + " " + mem.Review);
                update += mem.ProductId + " "+mem.Review+" ";
            }
            return update;
        }
        ///skip top 5 records
        public static List<int> SkipTopFiveRecords(List<ReviewProduct> products)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Skip Top Five records in list");
            var result = (from product in products orderby product.rating descending select product).Skip(5).ToList();
            foreach(var mem in result)
            {
                list.Add(mem.userId);
                Console.WriteLine(mem.userId);
            }
            return list;
        }
        
        /// Display the details in list
        public static void DisplayList(List<ReviewProduct> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine("ProductId:{0} | UserId:{1} | Review:{2} | Rating:{3} | IsLike:{4}", product.productId, product.userId, product.review, product.rating, product.isLike);
            }
        }
    }
}
