using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//using WcfServices.Model;
using DataLayer.Concrete;
using DataLayer.Entities;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ProductService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ProductService.svc или ProductService.svc.cs в обозревателе решений и начните отладку.
    public class ProductService : IProductService //localhost:55269/Properties/
    {
        ProductRepository repository = new ProductRepository();
        //ProductContext db = new ProductContext();
        [OperationBehavior]
        public List<Product> GetAllProducts()
        {
            return repository.Products.ToList();          
        }
        [OperationBehavior]
        public Product GetProduct(int id)
        {
            return repository.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
