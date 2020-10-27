using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointReaction.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Leaderboard()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }
    }
}