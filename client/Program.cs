using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService.ProductServiceClient client = new ProductService.ProductServiceClient();
            //string p = client.GetProduct(1);
            //Console.WriteLine(p);
        }
    }
}
