using Microsoft.AspNetCore.Mvc;
using Prueba.Extensions;

namespace Prueba.Controllers
{
    public class AdminControllerBase : ControllerBase
    {

        protected int GetAdminId()
        {
            if (User.Identity == null) throw new ArgumentException("Unauthorized");
            var id =  User.Identity.GetId();
            if (id == -1) throw new ArgumentException("Unauthorized");
            return id;
        }

        protected string GetAdminUsername()
        {
            if (User.Identity == null) throw new ArgumentException("Unauthorized");
            var username = User.Identity.GetUsername();
            if (username == null || username == "") throw new ArgumentException("Unauthorized");
            return username;
        }
    }
}
