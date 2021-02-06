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
    [Route("api/[controller]")] // api/positions
    [ApiController]
    public class Positions : ControllerBase
    {
        private readonly CompanyDB _db;
        public Positions(CompanyDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Position> GetAllPositions()
        {
            return _db.Position.ToArray();
        }
        [HttpGet("add/{title}/{typeofpositionid}")]
        public void AddPosition(string title, int typeofpositionid)
        {
            Position pos = new Position
            {
                Title = title,
                TypeOfPositionId = typeofpositionid
            };
            _db.Position.Add(pos);
            _db.SaveChanges();
        }
        [HttpGet("update/{id}/{title}/{typeofpositionid}")]
        public void UpdatePosition(int id, string title, int typeofpositionid)
        {
            Position pos = _db.Position.FirstOrDefault(p => p.Id == id);
            if (pos != null)
            {
                pos.Title = title;
                pos.TypeOfPositionId = typeofpositionid;
                _db.Position.Update(pos);

            }
            _db.SaveChanges();
        }
        [HttpGet("remove/{id}")]
        public void RemovePosition(int id)
        {
            Position pos = _db.Position.FirstOrDefault(p => p.Id == id);
            if (pos != null) _db.Position.Remove(pos);
            _db.SaveChanges();
        }

    }
}
