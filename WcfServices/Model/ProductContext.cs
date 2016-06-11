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

                defaultProducts.Add(new Product() { Name = "Мяч", Description = "Отличный кожаный мяч для игры в футбол", PictureUrl = "http://www.sportvokrug.ru/f/1/statyi_o_sporte/foot-ball/football3.png", Price = 10m });
                defaultProducts.Add(new Product() { Name = "Катана", Description = "Ритуальный японский меч", PictureUrl = "http://vignette4.wikia.nocookie.net/walkingdead/images/8/89/Katana-nagaiTV.jpg/revision/latest?cb=20130709235338&path-prefix=ru", Price =1500m  });
                defaultProducts.Add(new Product() { Name = "Ручка", Description = "Дешевая китайская шариковая ручка", PictureUrl = "http://pradv.ru/wp-content/uploads/2014/10/%D1%88%D0%B0%D1%80%D0%B8%D0%BA%D0%BE%D0%B2%D0%B0%D1%8F-%D1%80%D1%83%D1%87%D0%BA%D0%B0.jpg", Price= 1m });
                defaultProducts.Add(new Product() { Name = "Слон", Description = "Африканский слон с большими ушами", PictureUrl = "http://www.molomo.ru/img/ele1.jpg", Price = 4000m });
                defaultProducts.Add(new Product() { Name = "Iphone", Description = "Телефон с логотипом надкусанного яблока", PictureUrl = "http://play-mart.ru/img/cms/2153467134763254.jpg", Price = 650m });
                defaultProducts.Add(new Product() { Name = "Программист Лёха", Description = "Жарит код. Стоит дешевле айфона в месяц", PictureUrl = "https://pp.vk.me/c425724/v425724200/607e/jl1-CKU4W1s.jpg", Price = 500m });


                foreach (var prod in defaultProducts)
                    context.Products.Add(prod);

                base.Seed(context);
            }
        }
    }
}
