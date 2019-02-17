using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using WebMarket.Data;
using WebMarket.Data.Repositories.Security;

namespace WebMarket.Services
{
    public static class BootStrap
    {
        public static void Initializer()
        {
            var container = new UnityContainer();

            // Repo
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();


            // Services
            container.RegisterType<ISecurityService, SecurityService>();

            // Misc
            container.RegisterSingleton<DataContext>();
        }
    }
}
