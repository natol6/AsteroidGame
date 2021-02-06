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
    [Route("api/[controller]")] // api/typeofpositions
    [ApiController]
    public class TypeOfPositions : ControllerBase
    {
        private readonly CompanyDB _db;
        public TypeOfPositions(CompanyDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<TypeOfPosition> GetAllTypeOfPositions()
        {
            return _db.TypeOfPosition.ToArray();
        }
        [HttpGet("add/{title}")]
        public void AddTypeOfPosition(string title)
        {
            TypeOfPosition top = new TypeOfPosition
            {
                Title = title,
            };
            _db.TypeOfPosition.Add(top);
            _db.SaveChanges();
        }
        [HttpGet("update/{id}/{title}")]
        public void UpdateTypeOfPosition(int id, string title)
        {
            TypeOfPosition top = _db.TypeOfPosition.FirstOrDefault(t => t.Id == id);
            if (top != null)
            {
                top.Title = title;
                _db.TypeOfPosition.Update(top);
            }
            _db.SaveChanges();
        }
        [HttpGet("remove/{id}")]
        public void RemoveTypeOfPosition(int id)
        {
            TypeOfPosition top = _db.TypeOfPosition.FirstOrDefault(t => t.Id == id);
            if (top != null) _db.TypeOfPosition.Remove(top);
            _db.SaveChanges();
        }
    }
}
