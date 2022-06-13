using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Field.Models;
using DBCon;
using Microsoft.AspNetCore.Mvc;

namespace Core_Field.Controllers
{
    public class UserController : Controller
    {
        protected DatabaseContext db;

        public UserController(DatabaseContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {

            var q = db.tbl_User.Select(u => u).ToList();


            return View(q);
        }
      /* public IActionResult Signin()
       {
            return View();
       }
      
        public IActionResult Signin( User us)
        {

            var q = db.tbl_User.Select(u => u.Email == us.Email && u.Password == us.Password).ToList();


            return View(q);

        }*/
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            string message = string.Empty;
            if(!db.tbl_User.Any(u => u.Email == model.Email))
            {
                db.tbl_User.Add(model);
                db.SaveChanges();
                message = "Data inserted successfully";
                return Json(message);


            }
            message = "User with this Email Already Exist";
            return Json(message);
        }
    }
}
