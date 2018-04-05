using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;

using WebApplicationDay3.Helpers;
using WebApplicationDay3.Models;



namespace WebApplicationDay3.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            string sql = @"select * from people";

            SqlDataReader dr = DBUtil.GetDataReader(sql);
            ViewBag.dr = dr;

            return View();
        }


        public ActionResult GetPerson(int id)
        {
            string sql = @"select * from people where personid=" + id.ToString();

            SqlDataReader dr = DBUtil.GetDataReader(sql);
            ViewBag.dr = dr;

            return View();
        }

        [HttpGet]
        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(string PersonFirstName, string PersonLastName,string PersonBirthDate, string PersonEmail)
        {
            bool saved = true;
            bool isDataValid = true;
            string errorMessage = "";

            if(PersonEmail.Contains("aol"))
            {
                isDataValid = false;
                errorMessage = @"aol not allowed...";
            }

            if (isDataValid)
            {
                Person p = new Person();
                //p.PersonID = PersonID;
                p.PersonLastName = PersonLastName;
                p.PersonFirstName = PersonFirstName;
                p.PersonBirthDate = DateTime.Parse(PersonBirthDate);
                p.PersonEmail = PersonEmail;
                p.SavePerson();

                if (saved)
                {
                    Response.Redirect("index");

                }
            }
            else
            {
                ViewBag.ErrorMessage = errorMessage;
                ViewBag.personEmail = PersonEmail;
                ViewBag.personFirstName = PersonFirstName;
                ViewBag.personLastName = PersonLastName;
                ViewBag.personBirthDate = PersonBirthDate;
            }
            return View();
        }


    }
}