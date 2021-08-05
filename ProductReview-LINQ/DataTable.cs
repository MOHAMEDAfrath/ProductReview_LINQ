using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview_LINQ
{
   public class ProductDataTable
    {
        public static DataTable CreateDataTable(List<ReviewProduct> reviewProducts)
        {
            
            DataTable product = new DataTable();
            product.Columns.Add("productId");
            product.Columns.Add("userId");
            product.Columns.Add("rating");
            product.Columns.Add("review");
            product.Columns.Add("isLike", typeof(bool));

            foreach (var data in reviewProducts)
            {
                product.Rows.Add(data.productId, data.userId, data.rating, data.review, data.isLike);
            }
            return product;
            Display(product);
        }
        public static void Display(DataTable table)
        {
            foreach (DataRow p in table.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
            }
        }
    }
}
