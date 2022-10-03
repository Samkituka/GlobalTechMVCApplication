using GlobalTech.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTech.DataAccess.Context
{
    public class GlobalTechDbContext : DbContext
    {
        public GlobalTechDbContext (DbContextOptions <GlobalTechDbContext> options) :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
