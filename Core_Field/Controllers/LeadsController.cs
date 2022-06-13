using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCon;
using Microsoft.AspNetCore.Mvc;

namespace Core_Field.Controllers
{
    public class LeadsController : Controller
    {
        protected DatabaseContext db;

        public LeadsController(DatabaseContext _db)
        {
            db = _db;
        }
      
   
        public IActionResult Index()
        {

            var q = db.Lead.Select(u => u).ToList();
            return View(q);
         }
        public ActionResult NewPage(int Id)
        {
            var student = db.Lead
                              .Where(s => s.Id == Id)
                              .FirstOrDefault<Leads>();


            return View(student);
        }
        public IActionResult Delete(int Id)
        {
            Leads l = db.Lead.Find(Id);
            if (l != null)
            {
                db.Lead.Remove(l);
                db.SaveChanges();

            }
            return RedirectToAction("Index");   
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Leads le)
        {
            db.Lead.Update(le);
            db.SaveChanges();
            return RedirectToAction("Index", "Leads");

           
        }

        public IActionResult EditCustomer(int Id)
        {
            
                var student = db.Lead
                                .Where(s => s.Id == Id)
                                .FirstOrDefault<Leads>();
          

            return Json(student);

        }



    }
}
