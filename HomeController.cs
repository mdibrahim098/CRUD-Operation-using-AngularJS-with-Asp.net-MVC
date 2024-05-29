
using CRUDOperationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperationApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Student()
        {
            return View();
        }
        public string InsertStudentRecord(Student std)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Students.Add(std);
                db.SaveChanges();
                return "Student Added Successfully!";
            }
        }
        public JsonResult GetAllStudent()
        {
            DBEntities db = new DBEntities();
            var AllRecord = db.Students.ToList();
            return Json(AllRecord, JsonRequestBehavior.AllowGet);
        }

        public string UpdateStudentRecord(Student std)
        {
            using (DBEntities db = new DBEntities())
            {
                var record  = db.Students.Where(x=> x.ID == std.ID).FirstOrDefault();
                record.Name = std.Name; 
                record.Age = std.Age;   
                record.Department = std.Department;
                db.SaveChanges();
                return "Student Record Updated Successfully";

            }
            
            
        }

        public string DeletedStudent(Student std)
        {
            using (DBEntities db = new DBEntities())
            {
                var data = db.Students.Where(x => x.ID == std.ID).FirstOrDefault();
                db.Students.Remove(data);
                db.SaveChanges();
                return (" Record Deleted Successfully");
                    
            }
        }

    }
}