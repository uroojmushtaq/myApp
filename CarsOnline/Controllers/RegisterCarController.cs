using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsOnline.Models;
using CarsOnline.Entities;
using CarsOnline.DAL;

namespace CarsOnline.Controllers
{
    public class RegisterCarController : Controller
    {
        //
        // GET: /RegisterCar/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ViewRecord()
        {

            //CarsDTO dto = new CarsDTO();
            //CarsDAO dao = new CarsDAO();
            //dto.Name = "honda";
            //dto.Price = 1200000;
            //ViewBag.car = dto;

            CarsDAO dao = new CarsDAO();

            var login = Session["login1"];
            UserDTO udto= new UserDTO();
            udto.TxtLogin = (string)login;

            List<CarsDTO> list = dao.getRecord(udto);




            return View(list);
        }

        public ActionResult Register(Car model)
        {
            CarsDTO dto = new CarsDTO();

            CarsDAO dao = new CarsDAO();

            if (ModelState.IsValid)
            {
                dto.Name = model.Name;
                dto.Price = model.Price;


                if (model.Price < 1000000)
                {
                    ViewBag.msg = "Too Low Price!!!";
                    return View("Index");
                }
                else
                {

                    var login = Session["login1"];
                    UserDTO dto1 = new UserDTO();
                    dto1.TxtLogin = (string)login;
                    dao.purchaseCar(dto1, dto);
                    return View("Index");

                }


           
            }

            return View("Signup");
            
        }
    }
}
