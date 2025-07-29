using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrador.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Meseros()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult BadTender()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Confirmados()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Finalizados()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Ingresos()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult logistica()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Menu()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Otros()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Pendiente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Personal()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult PersonalRegister()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}