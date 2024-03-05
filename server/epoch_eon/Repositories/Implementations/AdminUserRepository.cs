using Prueba.Data;
using Prueba.Models;

namespace Prueba.Repositories.Implementations
{
    public class AdminUserRepository : IAdminUserRepository
    {

        private AppDBContext _context;

        public AdminUserRepository(AppDBContext context)
        {
            _context = context;
        }

        public AdminUser? GetByUsername(string username)
        {
            return _context.AdminUsers.Where(a => a.Username.Equals(username.ToLower())).FirstOrDefault();
        }

        AdminUser? IAdminUserRepository.GetByEmail(string email)
        {
            return _context.AdminUsers.Where(a => a.Email.Equals(email.ToLower())).FirstOrDefault();
        }

        public void Insert(AdminUser adminUser)
        {
            _context.AdminUsers.Add(adminUser);
            Save();
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
