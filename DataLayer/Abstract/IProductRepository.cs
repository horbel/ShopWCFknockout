using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product SaveProduct(Product product);
        bool DeleteProduct(int productID);
    }
}
