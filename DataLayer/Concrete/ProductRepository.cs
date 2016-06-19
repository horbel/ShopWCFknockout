using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;
using DataLayer.Abstract;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataLayer.Concrete
{
    public class ProductRepository : IProductRepository
    {
       
        private ProductContext context = new ProductContext();
        
        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntity = context.Products.Find(productID);
            if (dbEntity != null)
            {
                context.Products.Remove(dbEntity);
                context.SaveChanges();
            }
            return dbEntity;
        }
        //this method for edit and create new products
        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntity = context.Products.Find(product.Id);
                if (dbEntity != null)
                {                    
                    dbEntity.Name = product.Name;                    
                    dbEntity.Description = product.Description;
                    dbEntity.Price = product.Price;
                    dbEntity.PictureUrl = product.PictureUrl;                    
                }

            }
            context.SaveChanges();
        }
    }
}
