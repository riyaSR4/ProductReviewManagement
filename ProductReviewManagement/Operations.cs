using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Operations
    {
        DataTable table = new DataTable();
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
        public void AddDataToDataTable(List<Product> list)
        {
            table.Columns.Add("ProductId").DataType = typeof(Int32);
            table.Columns.Add("UserId").DataType = typeof(Int32);
            table.Columns.Add("Rating").DataType = typeof(Int32);
            table.Columns.Add("Review").DataType = typeof(string);
            table.Columns.Add("IsLike").DataType = typeof(bool);
            foreach (var data in list)
            {
                table.Rows.Add(data.ProductID, data.UserID, data.Rating, data.Review, data.isLike);
            }
            foreach (var item in table.AsEnumerable())
            {
                Console.WriteLine(item.Field<int>("ProductId") + " " + item.Field<int>("UserID") 
                    + " " + item.Field<int>("Rating") + " " + item.Field<string>("Review") + " " 
                    + item.Field<bool>("isLike"));
            }
        }
        public void RetrieveRecordsFromDataTable()
        {
            var result = table.AsEnumerable().Where(x => x.Field<bool>("IsLike").Equals(true));
            foreach (var item in result.AsEnumerable())
            {
                Console.WriteLine(item.Field<int>("ProductId") + " " + item.Field<int>("UserID")
                    + " " + item.Field<int>("Rating") + " " + item.Field<string>("Review") + " "
                    + item.Field<bool>("isLike"));
            }
        }
        public void AvgRating(List<Product> list)
        {
            var result = list.Average(x => x.Rating);
            Console.WriteLine(result);
        }
        public void RetrieveUsingReview(List<Product> list)
        {
            var result = list.Where(x => x.Review.Equals("Nice"));
            Display(result.ToList());
        }
        public void RetrieveUsingRating(List<Product> list)
        {
            var result = list.Where(x => x.UserID.Equals(10)).OrderBy(x => x.Rating);
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
