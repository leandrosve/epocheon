using EpochEon.Extensions;
using EpochEon.Models;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Repositories.Implementations
{
    public class ProductsRepository : IProductsRepository
    {

        private AppDBContext _context;

        public ProductsRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.BuildProduct().ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.BuildProduct().Where(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public Product? GetByIdAndStatus(int id, ProductStatus status)
        {
            return _context.Products.BuildProduct().Where(a => a.Id.Equals(id) && a.Status == status).FirstOrDefault();
        }

        public Product? GetByTitle(string title)
        {
            return _context.Products.BuildProduct().Where(a => a.Title.ToLower().Equals(title.ToLower())).FirstOrDefault();
        }

        public Product Insert(Product product)
        {
            _context.Products.Add(product);
            Save();
            return product;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
