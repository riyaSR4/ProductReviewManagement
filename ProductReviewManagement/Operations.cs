using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Operations
    {
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
