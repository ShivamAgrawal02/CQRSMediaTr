using CQRSMediaTr.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Data
{
    public class CQRSMediaTrDbContext:DbContext
    {
        public CQRSMediaTrDbContext(DbContextOptions<CQRSMediaTrDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
