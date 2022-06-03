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
    public class AdidasController : Controller
    {
        
  
        // GET: Adidas
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListAdidasPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
    }
}