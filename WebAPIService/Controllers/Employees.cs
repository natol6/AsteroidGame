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
        [HttpGet("add/{surname}/{name}/{middlename}/{positionid}/{depatmentid}")]
        public void AddEmployee(string surname, string name, string middlename, int positionid, int depatmentid)
        {
            Employee empl = new Employee
            { Surname = surname,
                Name = name,
                MiddleName = middlename,
                PositionId = positionid,
                DepatmentId = depatmentid
            };
            _db.Employee.Add(empl);
            _db.SaveChanges();
        }
        [HttpGet("update/{id}/{surname}/{name}/{middlename}/{positionid}/{depatmentid}")]
        public void UpdateEmployee(int id, string surname, string name, string middlename, int positionid, int depatmentid)
        {
            Employee empl = _db.Employee.FirstOrDefault(employee => employee.Id == id);
            if(empl != null)
            {
                empl.Surname = surname;
                empl.Name = name;
                empl.MiddleName = middlename;
                empl.PositionId = positionid;
                empl.DepatmentId = depatmentid;
                _db.Employee.Update(empl);
                
            }
            _db.SaveChanges();
        }
        [HttpGet("remove/{id}")]
        public void RemoveEmployee(int id)
        {
            Employee empl = _db.Employee.FirstOrDefault(employee => employee.Id == id);
            if (empl != null) _db.Employee.Remove(empl);
            _db.SaveChanges();
        }


    }
}
