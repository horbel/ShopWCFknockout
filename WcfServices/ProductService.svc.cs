﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Model;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ProductService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ProductService.svc или ProductService.svc.cs в обозревателе решений и начните отладку.
    public class ProductService : IProductService
    {
        ProductContext db = new ProductContext();

        public List<Product> GetAllProducts()
        {
            Console.WriteLine(db.Products.FirstOrDefault(x => x.Id == 1).Name);
            return db.Products.ToList();            
        }
        public string GetName(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id).Name;
        }
    }
}
