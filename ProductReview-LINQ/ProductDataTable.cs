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
        //created datatable
        public static DataTable CreateDataTable(List<ReviewProduct> reviewProducts)
        {
            
            DataTable product = new DataTable();
            product.Columns.Add("productId",typeof(int));
            product.Columns.Add("userId",typeof(int));
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
        //returns data if islike is true
        public static List<int> ReturnsOnlyIsLikeFieldAsTrue(DataTable dataTable)
        {
            List<int> list = new List<int>();
            List<ReviewProduct> products = new List<ReviewProduct>();
            var result = from product in dataTable.AsEnumerable() where product.Field<bool>("isLike") == true select product;
            foreach (var mem in result)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", mem["productId"], mem["userId"], mem["rating"], mem["review"], mem["isLike"]);
                list.Add(Convert.ToInt32(mem["userId"]));
            }
            return list;
        }
    }
}
