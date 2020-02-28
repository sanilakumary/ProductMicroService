using ProductMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Repository
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductId);
        void InserProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
        void Save();

    }
}
