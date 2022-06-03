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
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1,int pageSize = 2)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(USER user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.MATKHAU);
                user.MATKHAU = encryptedMd5Pas;
                var encryptedMd5Pass = Encryptor.MD5Hash(user.REPASS);
                user.REPASS = encryptedMd5Pass;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View("Index");
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(USER user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(!string.IsNullOrEmpty(user.MATKHAU))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.MATKHAU);
                    user.MATKHAU = encryptedMd5Pas;
                }
                if (!string.IsNullOrEmpty(user.MATKHAU))
                {
                    var encryptedMd5Pass = Encryptor.MD5Hash(user.REPASS);
                    user.REPASS = encryptedMd5Pass;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
