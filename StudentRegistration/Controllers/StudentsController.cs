using StudentRegistration.DataAccessLayer;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDAL _studentDAL = new StudentDAL();
        // GET: Students

        public ActionResult Index()
        {
            List<Student> students = _studentDAL.GetAllStudents();
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            Student obj = new Student();
            return View(obj);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (student != null)
                
            {
                _studentDAL.AddStudent(student);
                //return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Students");
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = _studentDAL.GetStudentById(id);
            if (student == null)
            {
                return View();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                _studentDAL.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = _studentDAL.GetStudentById(id);
            if (student == null)
            {
                return View();
            }
            return View(student);
        }

        // DELETE: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentDAL.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
