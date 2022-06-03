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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dao = new UserDao();
            ViewBag.NikeProduct1 = dao.ListNikeProduct1(4);
            ViewBag.NikeProduct2 = dao.ListNikeProduct2(4);
            ViewBag.AdidasProduct1 = dao.ListAdidasProduct1(4);
            ViewBag.AdidasProduct2 = dao.ListAdidasProduct2(4);
            return View();
        }

        public ActionResult Details(int id)
        {
            Model_shop db = new Model_shop();
            return View(db.SANPHAMs.Where(s => s.IDSANPHAM == id).FirstOrDefault());
        }
    }
}