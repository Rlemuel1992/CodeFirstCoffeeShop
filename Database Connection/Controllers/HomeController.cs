using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database_Connection.Models;
using Dapper;

namespace Database_Connection.Controllers
{
	public class HomeController : Controller
	{
		

public ActionResult Index()
		{
			List<Products> AllProducts = new List<Products>();
			using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-6M65FED7\\SQLEXPRESS;Initial Catalog=Database_Connection.Models.ItemDBContext;Integrated Security=True"))
			{
				var selectQueryString = "SELECT * FROM Products";
				AllProducts = connection.Query<Products>(selectQueryString).ToList();

			}
			Session["AllProducts"] = AllProducts;
			return View();
		}

		public ActionResult Login()
		{
			return View();
		}

		public ActionResult Register()
		{
			return View("Create","Users");
		}

		
		public ActionResult ValidateLogin()
		{
			

				return View();
		}

		public ActionResult Shop()
		{
			var ShopDB = new ItemDBContext();


			return View(ShopDB);
		}
	}
}