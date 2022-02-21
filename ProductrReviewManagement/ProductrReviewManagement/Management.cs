using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductrReviewManagement
{
    internal class Management
    {
        public readonly DataTable dt = new DataTable();
        /// <summary>
        /// UC2
        /// </summary>
        /// <param name="listProductReview"></param>
        /// // retrive top 3 records
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3).ToList();
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductID + " UserID: " + list.UserID + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.isLike);
            }
        }
        //retireve by rating & bproductID
        public void RecordWithCondition(List<ProductReview> listProductReview)
        {
            var data = (from productReviews in listProductReview
                        where (productReviews.Rating > 3 && productReviews.ProductID == 1) || (productReviews.Rating > 3 && productReviews.ProductID == 4)
                                || (productReviews.Rating > 3 && productReviews.ProductID == 9)
                        select productReviews).ToList();
            Console.WriteLine("\n");
            foreach (var list in data)
            {
                Console.WriteLine("ProductID: " + list.ProductID + " UserID: " + list.UserID + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.isLike);
            }
        }
        //retreive by count of review
        public void RetrieveCountOfReview(List<ProductReview> listProductReview)
        {
            var data = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });

            Console.WriteLine("\n");
            foreach (var list in data)
            {
                Console.WriteLine(list.ProductID + " ------- " + list.Count);
            }
        }

    }
}
