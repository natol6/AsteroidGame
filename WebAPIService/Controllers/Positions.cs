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
        [HttpGet("getEndPosition")]
        public Position GetEndPosition()
        {
            return _db.Position.OrderBy(p => p.Id).LastOrDefault();
        }
        [HttpPost]
        public void AddPosition(Position pos)
        {
            _db.Position.Add(pos);
            _db.SaveChanges();
        }
        [HttpPut("{Id}")]
        public void UpdatePosition(int id, Position pos)
        {
            Position posdb = _db.Position.FirstOrDefault(p => p.Id == id);
            if (posdb != null)
            {
                posdb.Title = pos.Title;
                posdb.TypeOfPositionId = pos.TypeOfPositionId;
                _db.Position.Update(posdb);

            }
            _db.SaveChanges();
        }
        [HttpDelete("{Id}")]
        public void RemovePosition(int id)
        {
            Position pos = _db.Position.FirstOrDefault(p => p.Id == id);
            if (pos != null) _db.Position.Remove(pos);
            _db.SaveChanges();
        }

    }
}
