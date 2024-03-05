using Prueba.Models;

namespace Prueba.Repositories
{
    public interface IAdminUserRepository
    {

        AdminUser? GetByUsername(string username);
        AdminUser? GetByEmail(string email);
        void Insert(AdminUser adminUser);
        void Save();

    }
}
