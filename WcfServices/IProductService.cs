using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//using WcfServices.Model;
using DataLayer.Entities;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IProductService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProducts();
        [OperationContract]
        Product GetProduct(int id);
        [OperationContract]
        Product SaveProduct(Product product);
        [OperationContract]
        bool DeleteProduct(int productID);
    }
}
