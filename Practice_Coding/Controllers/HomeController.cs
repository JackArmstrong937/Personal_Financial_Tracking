using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice_Coding.Models;
using Practice_Coding.DAL;

namespace Practice_Coding.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return Redirect("/home/overview");
		}
		public ActionResult JackTest()
		{
			Categories AllCats = CategoryDAL.Amounts();

			//The long way
			//Category NewCat1 = new Category();
			//NewCat1.CategoryID = 1;
			//NewCat1.CategoryName = "Cars";
			//NewCat1.Active = true;
			//AllCats.Add(NewCat1);

			//The short way
			//AllCats.Add(new Category() { CategoryID = 1, CategoryName = "Cars", Active = true });
			//AllCats.Add(new Category() { CategoryID = 2, CategoryName = "Other", Active = true });
			//AllCats.Add(new Category() { CategoryID = 3, CategoryName = "School", Active = false });



			return View(AllCats);
		}

		[HttpGet]
		public ActionResult Overview ()
		{
			Overview_Page_VM model = new Overview_Page_VM();
			model.Category_Totals = CategoryDAL.Amounts();

			model.New_Transactions = new List<Transaction>();
			for(int i = 0; i < model.Category_Totals.Count; i++)
            {
				model.New_Transactions.Add(new Transaction() {
					TransactionID = -1, 
					TransactionDate = DateTime.Now ,
					CategoryID = model.Category_Totals[i].CategoryID,
					CategoryName = model.Category_Totals[i].CategoryName
				});
            }

			return View(model);
		}

		[HttpPost]
		public ActionResult Overview(Overview_Page_VM Model)
		{
			//Save if we have a new category name
			if (!string.IsNullOrWhiteSpace(Model.New_Category_Name))
			{
				Category newCat = new Category();
				newCat.CategoryID = -1;
				newCat.CategoryName = Model.New_Category_Name;
				newCat.Active = true;
				CategoryDAL.Save(newCat);
			}

			//reload the page
			Overview_Page_VM model = new Overview_Page_VM();
			model.Category_Totals = CategoryDAL.Amounts();
			return View(model);
		}


	}
}