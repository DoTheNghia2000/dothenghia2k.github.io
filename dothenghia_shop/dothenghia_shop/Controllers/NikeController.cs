using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.Dao;
using dothenghia_shop.Common;
using PagedList;

namespace dothenghia_shop.Controllers
{
    public class NikeController : Controller
    {
        // GET: Nike
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListNikePaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
    }
}