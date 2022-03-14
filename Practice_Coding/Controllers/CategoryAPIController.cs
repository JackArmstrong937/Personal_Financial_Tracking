using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice_Coding.Models;
using Practice_Coding.DAL;

namespace Practice_Coding.Controllers
{
    public class CategoryAPIController : Controller
    {
        [HttpGet]
        public JsonResult ListWithTotals()
        {
            return Json(CategoryDAL.Amounts(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListWithTotalsView()
        {
            return View(CategoryDAL.Amounts());
        }

        [HttpPost]
        public void Save(Category cat)
        {
			CategoryDAL.Save(cat);
        }
    }
}