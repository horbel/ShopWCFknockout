using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer.Entities;
using DataLayer.Abstract;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ProductService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ProductService.svc или ProductService.svc.cs в обозревателе решений и начните отладку.
    public class ProductService : IProductService //localhost:55269/Properties/
    {
        private IProductRepository repository;
        //DI using ninject.extension.wcf
        public ProductService(IProductRepository repoParam)
        {
            repository = repoParam;
        }        

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
        [OperationBehavior]
        public Product SaveProduct(Product product)
        {
            repository.SaveProduct(product);
            return product;
        }
        [OperationBehavior]
        public bool DeleteProduct(int productID)
        {
            if (repository.DeleteProduct(productID))
                return true;
            return false;
        }
    }
}
