using MVCEmployee.Context;
using MVCEmployee.Models;
using MVCEmployee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller

    {

        private IEmployeeRepo<Employee> _repository = null;

        public EmployeeController()
        {
            this._repository = new EmployeeRepo<Employee>();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _repository.GetAll();

            return View(employees);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult Edit(int? id)
        {
            var employee = _repository.GetById(id);

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult Details(int? id)
        {
            var employee = _repository.GetById(id);

            return View(employee);
        }
        public ActionResult Delete(int? id)
        {
            var employee = _repository.GetById(id);

            return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
             _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}