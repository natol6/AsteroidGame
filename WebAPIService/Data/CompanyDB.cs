using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIService.Models;

namespace WebAPIService.Data
{
    public class CompanyDB: DbContext
    {
        public DbSet<Depatment> Depatment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<TypeOfPosition> TypeOfPosition { get; set; }

        public CompanyDB(DbContextOptions<CompanyDB> options) : base(options)
        {

        }
    }
}
