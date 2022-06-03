using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.Dao
{
    public class UserDao
    {
        Model_shop db = null;
        public UserDao()
        {
            db = new Model_shop();
        }
        public List<SANPHAM> ListNikeProduct1(int top)
        {
            return db.SANPHAMs.Where(x => x.HANGSANXUAT == "Nike" && (x.TOPHOT != null || x.SALE != null)).OrderByDescending(x => x.IDSANPHAM).Take(top).ToList();
        }
        public List<SANPHAM> ListNikeProduct2(int top)
        {
            return db.SANPHAMs.Where(x => x.HANGSANXUAT == "Nike").OrderByDescending(x => x.IDSANPHAM).Take(top).ToList();
        }
        public List<SANPHAM> ListAdidasProduct1(int top)
        {
            return db.SANPHAMs.Where(x => x.HANGSANXUAT == "Adidas" && (x.TOPHOT != null || x.SALE != null)).OrderByDescending(x => x.IDSANPHAM).Take(top).ToList();
        }
        public List<SANPHAM> ListAdidasProduct2(int top)
        {
            return db.SANPHAMs.Where(x => x.HANGSANXUAT == "Adidas").OrderByDescending(x => x.IDSANPHAM).Take(top).ToList();
        }
        public long Insert(USER entity)
        {
            db.USERS.Add(entity);
            db.SaveChanges();
            return entity.IDUSER;
        }
        public bool Update(USER entity)
        {
            try
            {
                var user = db.USERS.Find(entity.IDUSER);
                user.TEN = entity.TEN;
                if (!string.IsNullOrEmpty(entity.MATKHAU))
                {
                    user.MATKHAU = entity.MATKHAU;
                }
                user.EMAIL = entity.EMAIL;
                if (!string.IsNullOrEmpty(entity.REPASS))
                {
                    user.REPASS = entity.REPASS;
                }
                user.TRANGTHAI = entity.TRANGTHAI;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.USERS.Find(id);
                db.USERS.Remove(user);
                db.SaveChanges();
                return true;
            }   
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<USER> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<USER> model = db.USERS;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TEN.Contains(searchString));
            }
            return model.OrderByDescending(x => x.IDUSER).ToPagedList(page,pageSize);
        }

        public USER GetById(string userName)
        {
            return db.USERS.SingleOrDefault(x => x.TEN == userName);
        }
        public USER ViewDetail(int id)
        {
            return db.USERS.Find(id);
        }
        public int Login(string username, string password)
        {
            var resutl = db.USERS.SingleOrDefault(x => x.TEN == username);
            if (resutl == null)
            {
                return 0;
            }
            else
            {
                if(resutl.TRANGTHAI==false)
                {
                    return -1;
                }
                else
                {
                    if (resutl.MATKHAU == password)
                        return 1;
                    else
                        return -2;
                }
            }
        }

        public long Insert(SANPHAM entity)
        {
            db.SANPHAMs.Add(entity);
            db.SaveChanges();
            return entity.IDSANPHAM;
        }
        public bool Update(SANPHAM entity)
        {
            try
            {
                var user = db.SANPHAMs.Find(entity.IDSANPHAM);
                user.TENSANPHAM = entity.TENSANPHAM;
                user.HINHANH = entity.HINHANH;
                user.HANGSANXUAT = entity.HANGSANXUAT;
                user.GIATIEN = entity.GIATIEN;
                user.SIZE = entity.SIZE;
                user.MAUSAC = entity.MAUSAC;
                user.MOTA = entity.MOTA;
                user.TOPHOT = entity.TOPHOT;
                user.SALE = entity.SALE;
                user.DANHGIA = entity.DANHGIA;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete1(int id)
        {
            try
            {
                var user = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<SANPHAM> ListAllPaging1(string searchString, int page, int pageSize)
        {
            IQueryable<SANPHAM> model = db.SANPHAMs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENSANPHAM.Contains(searchString));
            }
            return model.OrderByDescending(x => x.TENSANPHAM).ToPagedList(page, pageSize);
        }

        public IEnumerable<SANPHAM> ListNikePaging(string searchString, int page, int pageSize)
        {
            IQueryable<SANPHAM> model = db.SANPHAMs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENSANPHAM.Contains(searchString));
            }
            return model.Where(x => x.HANGSANXUAT == "Nike").OrderByDescending(x => x.TENSANPHAM).ToPagedList(page, pageSize);
        }

        public IEnumerable<SANPHAM> ListAdidasPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SANPHAM> model = db.SANPHAMs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENSANPHAM.Contains(searchString));
            }
            return model.Where(x => x.HANGSANXUAT == "Adidas").OrderByDescending(x => x.TENSANPHAM).ToPagedList(page, pageSize);
        }

        public SANPHAM GetById1(string userName)
        {
            return db.SANPHAMs.SingleOrDefault(x => x.TENSANPHAM == userName);
        }
        public SANPHAM ViewDetail1(int id)
        {
            return db.SANPHAMs.Find(id);
        }
        public bool CheckUserName(string userName)
        {
            return db.USERS.Count(x => x.TEN == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.USERS.Count(x => x.EMAIL == email) > 0;
        }
    }
}
