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
        [HttpGet("add/{title}")]
        public void AddDepatment(string title)
        {
            Depatment dep = new Depatment
            {
                Title = title,
                
            };
            _db.Depatment.Add(dep);
            _db.SaveChanges();
        }
        [HttpGet("update/{id}/{title}")]
        public void UpdateDepatment(int id, string title)
        {
            Depatment dep = _db.Depatment.FirstOrDefault(d => d.Id == id);
            if (dep != null)
            {
                dep.Title = title;
                _db.Depatment.Update(dep);

            }
            _db.SaveChanges();
        }
        [HttpGet("remove/{id}")]
        public void RemoveDepatment(int id)
        {
            Depatment dep = _db.Depatment.FirstOrDefault(d => d.Id == id);
            if (dep != null) _db.Depatment.Remove(dep);
            _db.SaveChanges();
        }

    }
}
