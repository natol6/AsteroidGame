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
        [HttpGet("getEndTypeOfPosition")]
        public TypeOfPosition GetEndTypeOfPositon()
        {
            return _db.TypeOfPosition.OrderBy(t => t.Id).LastOrDefault();
        }
        [HttpPost]
        public void AddTypeOfPosition(TypeOfPosition top)
        {
            _db.TypeOfPosition.Add(top);
            _db.SaveChanges();
        }
        [HttpPut("{Id}")]
        public void UpdateTypeOfPosition(int id, TypeOfPosition top)
        {
            TypeOfPosition topdb = _db.TypeOfPosition.FirstOrDefault(t => t.Id == id);
            if (topdb != null)
            {
                topdb.Title = top.Title;
                _db.TypeOfPosition.Update(topdb);
            }
            _db.SaveChanges();
        }
        [HttpDelete("{Id}")]
        public void RemoveTypeOfPosition(int id)
        {
            TypeOfPosition top = _db.TypeOfPosition.FirstOrDefault(t => t.Id == id);
            if (top != null) _db.TypeOfPosition.Remove(top);
            _db.SaveChanges();
        }
    }
}
