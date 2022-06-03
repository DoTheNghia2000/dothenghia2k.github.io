using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.Dao;
using dothenghia_shop.Common;
using PagedList;

namespace dothenghia_shop.Areas.Admin.Controllers
{
    public class SanphamController : BaseController
    {
        // GET: Admin/Sanpham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging1(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/Sanpham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Sanpham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sanpham/Create
        [HttpPost]
        public ActionResult Create( SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                long id = dao.Insert(sanpham);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Sanpham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm San pham thành công");
                }
            }
            return View("Index");

        }

        // GET: Admin/Sanpham/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail1(id);
            return View(user);
        }

        // POST: Admin/Sanpham/Edit/5
        [HttpPost]
        public ActionResult Edit(SANPHAM user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "Sanpham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật san pham thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete1(id);
            return RedirectToAction("Index");
        }
    }
}
