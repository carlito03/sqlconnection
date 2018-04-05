using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDay3.Models;

using System.Data;
using System.Data.SqlClient;

namespace WebApplicationDay3.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            customers p = new customers();
            SqlDataReader dr = p.showCustomers();

            

            ViewBag.dr = dr;

            return View();
        }

        public ActionResult GetPerson(int id)
        {
            
            customers p = new customers();

            SqlDataReader dr = p.showOrders(id);
            ViewBag.dr = dr;

            return View();
        }


    }
}




