using BAL;
using HelperLibrary;
using SLSchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSchoolMVC.Controllers
{
    public class StudentController : Controller
    { // GET: Student
        Studentmethod cs = null;
        public StudentController()
        {
            cs = new Studentmethod();
        }
        public List<Studentlist> list1()
        {
            List<Studentlist> c1 = new List<Studentlist>();
            List<Studentdata> ds = cs.studentdatas();
            foreach (var item in ds)
            {
                Studentlist c = new Studentlist();
                c.Roll_no = item.Roll_no;
                c.StudentName = item.StudentName;
                c.Class = item.Class;
                c.Age = item.Age;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Studentlist> s1 = list1();
            return View(s1);
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(FormCollection c)
        {
            try
            {
                Studentdata s1 = new Studentdata();
                s1.Roll_no = Convert.ToInt32(Request["Roll_no"]);
                s1.StudentName = Request["StudentName"].ToString();
                s1.Class = Convert.ToInt32(Request["Class"]);
                s1.Age = Convert.ToInt32(Request["Age"]);
                cs.AddStudent(s1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Studentlist> m = list1();
            Studentlist m2 = m.Find(m3 => m3.Roll_no == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Studentdata s1 = new Studentdata();
                s1.Roll_no = Convert.ToInt32(Request["Roll_no"]);
                s1.StudentName = Request["StudentName"].ToString();
                s1.Class = Convert.ToInt32(Request["Class"]);
                s1.Age = Convert.ToInt32(Request["Age"]);
                cs.updateStudent(s1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Studentlist> m = list1();
            Studentlist m2 = m.Find(m3 => m3.Roll_no == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveStudent(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}