using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WcfServices.Model
{
    public class ProductContext: DbContext
    {
        public ProductContext() : base("ProductContext")
        {
            Database.SetInitializer<ProductContext>(new ProductDBInitializer());
        }
        public DbSet<Product> Products { get; set; }



        //class for hardcode default data
        public class ProductDBInitializer : DropCreateDatabaseAlways<ProductContext>
        {
            protected override void Seed(ProductContext context)
            {
                IList<Product> defaultProducts = new List<Product>();

                defaultProducts.Add(new Product() { Name = "Ball2", Description = "ball for play football" });
                defaultProducts.Add(new Product() { Name = "Sword", Description = "very sharp sword" });
                defaultProducts.Add(new Product() { Name = "Pen", Description = "blue pen" });

                foreach (var prod in defaultProducts)
                    context.Products.Add(prod);

                base.Seed(context);
            }
        }
    }
}
