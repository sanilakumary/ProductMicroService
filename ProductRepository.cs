using ProductMicroService.DBContexts;
using ProductMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void DeleteProduct(int ProductId)
        {
            var products = _productContext.Products.Find(ProductId);

            _productContext.Products.Remove(products);
            
        }

         public Product GetProductByID(int ProductId)
        {
            return _productContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }

         public void InserProduct(Product product)
        {
            _productContext.Products.Add(product);
            Save();
        }

        

        public void Save()
        {
            _productContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _productContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
