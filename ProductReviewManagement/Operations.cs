using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Operations
    {
        public void RetrieveTopRecords(List<Product> list)
        {
            var result = list.Where(x => x.Rating == 5).Take(3);
            Display(result.ToList());
        }
        public void RetrieveAllRecordsWithCondition(List<Product> list)
        {
            var result = list.Where(x => x.Rating > 3 && (x.ProductID == 1 || x.ProductID == 4 || x.ProductID == 9));
            Display(result.ToList());
        }
        public void UsingGroupBy(List<Product> list)
        {
            var result = list.GroupBy(x => x.ProductID).Select(x => new {ProductId = x.Key,Count = x.Count()});
            foreach(var data  in result)
            {
                Console.WriteLine(data.ProductId + " " + data.Count);
            }
        }
        public void RetrieveProductIdAndReview(List<Product> list)
        {
            var result = list.Select(x => new { ProductId = x.ProductID, Review = x.Review});
            foreach (var data in result)
            {
                Console.WriteLine(data.ProductId + " " + data.Review);
            }
        }
        public void SkipTopRecords(List<Product> list)
        {
            var result = list.Skip(5);
            Display(result.ToList());
        }
        public void Display(List<Product> list)
        {
            foreach (var data in list)
            {
                Console.WriteLine(data.ProductID + " " + data.UserID + " " + data.Rating + " " 
                    + data.Review + " " + data.isLike + " " );
            }
        }
    }
}
