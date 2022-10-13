using BAL;
using HelperLibrary;
using Microsoft.Ajax.Utilities;
using SLSchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSchoolMVC.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        Classmethod cs = null;
        public ClassController()
        {
            cs = new Classmethod();
        }
        public List<Classmodel> list1()
        {
            List<Classmodel> c1 = new List<Classmodel>();
            List<Classdata> ds = cs.classdatas();
            foreach (var item in ds)
            {
                Classmodel c = new Classmodel();
                c.Class_Id = item.Class_Id;
                c.Roll_no = item.Roll_no;
                c.Subject_Id = item.Subject_Id;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Classmodel> s1 = list1();
            return View(s1);
        }
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(FormCollection c)
        {
            try
            {
                Classdata c1 = new Classdata();
                c1.Class_Id = Convert.ToInt32(Request["Class_Id"]);
                c1.Roll_no = Convert.ToInt32(Request["Roll_no"]);
                c1.Subject_Id = Convert.ToInt32(Request["Subject_Id"]);

                cs.AddClass(c1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Classmodel> m = list1();
            Classmodel m2 = m.Find(m3 => m3.Class_Id == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Classdata c2 = new Classdata();
                c2.Class_Id = Convert.ToInt32(Request["Class_Id"]);
                c2.Roll_no = Convert.ToInt32(Request["Roll_no"]);
                c2.Subject_Id = Convert.ToInt32(Request["Subject_Id"]);
                cs.updateClass(c2);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Classmodel> m = list1();
            Classmodel m2 = m.Find(m3 => m3.Class_Id == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveClass(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}