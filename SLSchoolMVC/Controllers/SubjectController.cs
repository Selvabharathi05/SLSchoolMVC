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
    public class SubjectController : Controller
    {
        // GET: Subject
        SubjectMethods cs = null;
        public SubjectController()
        {
            cs = new SubjectMethods();
        }
        public List<Subjectmodel> list1()
        {
            List<Subjectmodel> c1 = new List<Subjectmodel>();
            List<Subjectdata> ds = cs.Subjlist();
            foreach (var item in ds)
            {
                Subjectmodel c = new Subjectmodel();
                c.SubjectId = item.SubjectId;
                c.SubjectName = item.SubjectName;

                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Subjectmodel> s1 = list1();
            return View(s1);
        }
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(FormCollection c)
        {
            try
            {
                Subjectdata s1 = new Subjectdata();
                s1.SubjectId = Convert.ToInt32(Request["SubjectId"]);
                s1.SubjectName = Request["SubjectName"].ToString();

                cs.AddSubject(s1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Subjectmodel> m = list1();
            Subjectmodel m2 = m.Find(m3 => m3.SubjectId == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Subjectdata s1 = new Subjectdata();
                s1.SubjectId = Convert.ToInt32(Request["SubjectId"]);
                s1.SubjectName = Request["SubjectName"].ToString();
                cs.updatesubject(s1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Subjectmodel> m = list1();
            Subjectmodel m2 = m.Find(m3 => m3.SubjectId == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveSubject(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}