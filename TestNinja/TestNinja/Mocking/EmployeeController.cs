using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeController(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeeStorage.DeleteEmployee(id);
            return RedirectToAction("Employee");
        }

        private ActionResult RedirectToAction(string v)
        {
            return new RedirectResult(v);
        }
    }
}
