using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using WebMarket.Services;

namespace WebMarket.WebApp.Controllers.Security
{
    public class SecurityController : Controller
    {
     [Dependency]
     public ISecurityService _securityService { get; set; }

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }


        // GET: Security
        public ActionResult UserIndex()
        {
            var users = _securityService.GetUsers(true);

            return View(users);
        }
    }
}