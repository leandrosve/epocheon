using Prueba.Data;
using Prueba.Models;

namespace Prueba.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private AppDBContext _context;

        public CategoriesRepository(AppDBContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.Where(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public Category? GetByTitle(string title)
        {
            return _context.Categories.Where(a => a.Title.ToLower().Equals(title.ToLower())).FirstOrDefault();
        }

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            Save();
            return category;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
