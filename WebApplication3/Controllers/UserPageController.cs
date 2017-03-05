using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class UserPageController : Controller
    {
        // GET: UserPage
        public ActionResult Index(int id)
        {
            ViewData["id"] = id;
            return View("UserPage", id);
        }
    }
}