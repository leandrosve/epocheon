using Elastic.Clients.Elasticsearch;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Repositories.Implementations
{
    public class BrandsRepository : IBrandsRepository
    {

        private AppDBContext _context;

        public BrandsRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public List<Brand> GetByCategory(int categoryId)
        {
            return _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Select(p => p.Brand)
            .Distinct()
            .ToList();
        }

        public Brand? GetById(int id)
        {
            return _context.Brands.Where(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public Brand? GetByName(string name)
        {
            return _context.Brands.Where(a => a.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public Brand Insert(Brand brand)
        {
            _context.Brands.Add(brand);
            Save();
            return brand;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
