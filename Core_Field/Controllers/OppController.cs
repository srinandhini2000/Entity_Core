using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCon;
using Microsoft.AspNetCore.Mvc;

namespace Core_Field.Controllers
{
    public class OppController : Controller
    {
        protected DatabaseContext db;

        public OppController(DatabaseContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var q = db.Opportunities.Select(u => u).ToList();
            return View(q);
            
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
