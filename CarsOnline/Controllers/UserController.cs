using CarsOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsOnline.DAL;
using CarsOnline.Models;

namespace CarsOnline.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }

       
  

        public ActionResult Signup()
        {
            return View();
        }


        ////[ActionName("Signup")]
        //[HttpPost]
        //public ActionResult Signup1(UserDTO dto )
        //{
        //    UserDAL ud = new UserDAL();

        //    if (ud.ifExists(dto))
        //    {
        //        ViewBag.message = "Username already exists, choose another one!!!";
        //        return Redirect("~/User/Signup");

        //    }
        //    else
        //    {
        //        ud.insertUser(dto);
        //        Session["Login"] = dto.TxtLogin;
        //        return Redirect("~/Home/Home");
        //    }  
        //}




        public ActionResult Signup1(Signup model)
        {
            UserDTO dto = new UserDTO();

            UserDAL dal = new UserDAL();

            if (ModelState.IsValid)
            {
                dto.TxtLogin = model.Username;
                dto.TxtName = model.Name;
                dto.TxtPassword = model.Password;
                if (dal.ifExists(dto))
                {
                    ViewBag.message = "Username already exists, choose another one!!!";
                    return View("Signup");

                }
                else
                {
                    dal.insertUser(dto);
                    Session["Login"] = dto.TxtLogin;
                    return Redirect("~/Home/Home1");
                }  
            }
            
          return Redirect("~/User/Signup");
        }



        public ActionResult Login1(Login model )
        {
            UserDTO dto = new UserDTO();

            UserDAL dal = new UserDAL();
            if (ModelState.IsValid)
            { 
                dto.TxtLogin = model.Username;
                dto.TxtPassword = model.Password;
                if (dal.ifExistsLogin(dto))
                {
                    ViewBag.msg = "valid Username/Password!";
                    Session["Login1"] = dto.TxtLogin;
                    return Redirect("~/Home/Home1");
                }
                else
                {
                    ViewBag.msg = "Invalid Username/Password! Enter Again.";
                     return View("Login");
                }
            }
            return View();
            
        }

        // [HttpPost]
        //public ActionResult Login1(UserDTO dto)
        //{
        //    UserDAL dal = new UserDAL();
        //    if (dal.ifExistsLogin(dto))
        //    {
        //        Session["Login1"] = dto.TxtLogin;
        //        return Redirect("~/Home/Home1");
        //    }
        //    else
        //    {
        //        ViewBag.msg = "User do not exists";
        //        return Redirect("~/User/Login");
        //    }
            
        //}

         public ActionResult Logout()
         {
             Session["Login"] = null;
             Session["Login1"] = null;
             Session.Abandon();
             return View("Login");
         }
    }
}
