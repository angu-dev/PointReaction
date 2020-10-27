using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointReaction.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Information()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}