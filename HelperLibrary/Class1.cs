using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using DAL;

namespace HelperLibrary
{
    public class Classmethod
    {
        public void AddClass(Classdata s)
        {
            SchoolEntities context = new SchoolEntities();
            Class s1 = new Class();
            s1.Class_id = s.Class_Id;
            s1.roll_no = s.Roll_no;
            s1.Subject_Id = s.Subject_Id;
            context.Classes.Add(s1);
            context.SaveChanges();


        }
        public bool RemoveClass(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.Class_id == id);
            if (s2 != null)
            {
                context.Classes.Remove(s2);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updateClass(Classdata s)
        {
            SchoolEntities context = new SchoolEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.Class_id == s.Class_Id);
            s2.Class_id = s.Class_Id;
            s2.roll_no = s.Roll_no;
            s2.Subject_Id = s.Subject_Id;
            context.SaveChanges();
        }
        public List<Classdata> classdatas()
        {
            SchoolEntities context = new SchoolEntities();
            List<Classdata> s = new List<Classdata>();
            List<Class> m1 = context.Classes.ToList();
            foreach (var item in m1)
            {
                s.Add(new Classdata
                {
                    Class_Id = item.Class_id,
                    Roll_no = (int)item.roll_no,
                    Subject_Id = (int)item.Subject_Id
                });
            }
            return s;
        }

    }
    public class Studentmethod
    {
        public void AddStudent(Studentdata s)
        {
            SchoolEntities context = new SchoolEntities();
            Student s1 = new Student();
            s1.Roll_no = s.Roll_no;
            s1.StudentName = s.StudentName;
            s1.Class = s.Class;
            s1.Age = s.Age;
            context.Students.Add(s1);
            context.SaveChanges();

        }
        public void RemoveStudent(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.Roll_no == id);
            context.Students.Remove(s1);
            context.SaveChanges();
        }
        public void updateStudent(Studentdata s2)
        {
            SchoolEntities context = new SchoolEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.Roll_no == s2.Roll_no);
            s1.Roll_no = s2.Roll_no;
            s1.StudentName = s2.StudentName;
            s1.Class = s2.Class;
            s1.Age = s2.Age;
            context.SaveChanges();
        }
        public List<Studentdata> studentdatas()
        {
            SchoolEntities context = new SchoolEntities();
            List<Studentdata> s = new List<Studentdata>();
            List<Student> s1 = context.Students.ToList();
            foreach (var item in s1)
            {
                s.Add(
                    new Studentdata
                    {
                        Roll_no = item.Roll_no,
                        StudentName = item.StudentName,
                        Class = (int)item.Class,
                        Age = (int)item.Age

                    }
                );
            }
            return s;
        }
    }
    public class SubjectMethods
    {
        public void AddSubject(Subjectdata s)
        {
            SchoolEntities context = new SchoolEntities();
            Subject s1 = new Subject();
            s1.Subject_Id = s.SubjectId;
            s1.Subject_Name = s.SubjectName;

            context.Subjects.Add(s1);
            context.SaveChanges();

        }
        public void RemoveSubject(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2 = s1.Find(m => m.Subject_Id == id);
            context.Subjects.Remove(s2);
            context.SaveChanges();
        }
        public void updatesubject(Subjectdata s)
        {
            SchoolEntities context = new SchoolEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2 = s1.Find(m => m.Subject_Id == s.SubjectId);
            s2.Subject_Id = s.SubjectId;
            s2.Subject_Name = s.SubjectName;
            context.SaveChanges();

        }
        public List<Subjectdata> Subjlist()
        {
            List<Subjectdata> s1 = new List<Subjectdata>();
            SchoolEntities context = new SchoolEntities();
            List<Subject> s = context.Subjects.ToList();
            foreach (var item in s)
            {
                s1.Add(
                    new Subjectdata
                    {
                        SubjectId = item.Subject_Id,
                        SubjectName = item.Subject_Name

                    });
            }
            return s1;
        }
    }
}

