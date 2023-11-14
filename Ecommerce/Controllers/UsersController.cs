using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class UsersController : Controller
    {
        DoAnEntities database = new DoAnEntities();
        // GET: Users
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {   
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.PhoneCus))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
             
                if (ModelState.IsValid)
                {
                    database.Customers.Add(cust);
                    database.SaveChanges();
                    return RedirectToAction("Login", "Users");

                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Ten dang nhap nay khong duoc de trong");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mat khau khong duoc de trong");
                if (ModelState.IsValid)
                {
                    var khachhang = database.Customers.FirstOrDefault(k => k.NameCus == cust.NameCus && k.PassCus == cust.PassCus);
                    if (khachhang != null)
                    {
                        Session["Ten"] = khachhang.NameCus;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng kiểm tra lại";
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(AdminUser ad)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ad.NameUser))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập này không được để trống");
                if (string.IsNullOrEmpty(ad.PasswordUser))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var admin = database.AdminUsers.FirstOrDefault(s => s.NameUser == ad.NameUser && s.PasswordUser == ad.PasswordUser);
                    if (admin != null)
                    {
                        Session["TenAD"] = admin.NameUser;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                       ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng kiểm tra lại";
                }
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        

        //Loix 
        public ActionResult Gioithieu()
        {
            return View();
        }

    }
}

