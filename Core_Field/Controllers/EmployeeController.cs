using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Field.Models;
using DBCon;
using Microsoft.AspNetCore.Mvc;

namespace Core_Field.Controllers
{
    public class EmployeeController : Controller
    {
        protected DatabaseContext db;

        public EmployeeController(DatabaseContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User us)
        {

            string msg = string.Empty;
            if (db.tbl_User.Any(u => u.Email == us.Email && u.Password == us.Password))
            {
                return RedirectToAction("Index","Leads");
            }
            else if (db.tbl_User.Any(u => us.Email == null && us.Password == null))
            {
                msg = "please enter the Values";
                return Json(msg);
            }
            else
            {
                ViewData["message"] = "Login Failed.......!";
                return View();
            }
           

        }

    }
}
