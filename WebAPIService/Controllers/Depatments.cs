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
    [Route("api/[controller]")] // api/depatments
    [ApiController]
    public class Depatments : ControllerBase
    {
        private readonly CompanyDB _db;
        public Depatments(CompanyDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Depatment> GetAllDepatments()
        {
            return _db.Depatment.ToArray();
        }
        [HttpGet("getEndDepatment")]
        public Depatment GetEndDepatment()
        {
            return _db.Depatment.OrderBy(d => d.Id).LastOrDefault();
        }
        [HttpPost]
        public void AddDepatment(Depatment dep)
        {
            _db.Depatment.Add(dep);
            _db.SaveChanges();
        }
        [HttpPut("{Id}")]
        public void UpdateDepatment(int id, Depatment dep)
        {
            Depatment depdb = _db.Depatment.FirstOrDefault(d => d.Id == id);
            if (depdb != null)
            {
                depdb.Title = dep.Title;
                _db.Depatment.Update(depdb);

            }
            _db.SaveChanges();
        }
        [HttpDelete("{Id}")]
        public void RemoveDepatment(int id)
        {
            Depatment dep = _db.Depatment.FirstOrDefault(d => d.Id == id);
            if (dep != null) _db.Depatment.Remove(dep);
            _db.SaveChanges();
        }

    }
}
