using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using WebMarket.Data;

namespace WebMarket.Services
{
    public static class BootStrap
    {
        public static void Initializer()
        {
            var container = new UnityContainer();

            // Repo

            // Services

            // Misc
            container.RegisterSingleton<DataContext>();
        }
    }
}
