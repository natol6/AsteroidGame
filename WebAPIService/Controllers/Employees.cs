using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIService.Models;
using WebAPIService.Data;

namespace WebAPIService.Controllers
{
    [Route("api/[controller]")] // api/employees
    [ApiController]
    public class Employees : ControllerBase
    {
        private readonly CompanyDB _db;
        public Employees(CompanyDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _db.Employee.ToArray();
        }
        [HttpGet("getEndEmployee")]
        public Employee GetEndEmployee()
        {
            return _db.Employee.OrderBy(e => e.Id).LastOrDefault();
        }
        [HttpPost]
        public void AddEmployee(Employee empl)
        {
            _db.Employee.Add(empl);
            _db.SaveChanges();
        }
        [HttpPut("{Id}")]
        public void UpdateEmployee(int id, Employee empl)
        {
            Employee empldb = _db.Employee.FirstOrDefault(employee => employee.Id == id);
            if(empldb != null)
            {
                empldb.Surname = empl.Surname;
                empldb.Name = empl.Name;
                empldb.MiddleName = empl.MiddleName;
                empldb.PositionId = empl.PositionId;
                empldb.DepatmentId = empl.DepatmentId;
                _db.Employee.Update(empldb);
                
            }
            _db.SaveChanges();
        }
        [HttpDelete("{Id}")]
        public void RemoveEmployee(int id)
        {
            Employee empl = _db.Employee.FirstOrDefault(employee => employee.Id == id);
            if (empl != null) _db.Employee.Remove(empl);
            _db.SaveChanges();
        }


    }
}
