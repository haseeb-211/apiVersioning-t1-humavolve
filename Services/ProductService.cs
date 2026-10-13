using ApiVersioning.Models;

namespace ApiVersioning.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int productId);
    }
    public class ProductService : IProductService
    {
        public Product GetProduct(int productId)
        {
            return GetProducts().FirstOrDefault(p=> p.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() {Id=1,Name="lenovo",Price=2500,Category="Labtop"},
                new Product() {Id=2,Name="samsung",Price=1500,Category="Phone"},
                new Product() {Id=3,Name="honor",Price=1000,Category="Watch"},

            };
        }
    }
}
