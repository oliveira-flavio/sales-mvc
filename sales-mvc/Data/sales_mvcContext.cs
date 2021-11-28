using Microsoft.EntityFrameworkCore;
using sales_mvc.Models;

namespace sales_mvc.Data
{
    public class sales_mvcContext : DbContext
    {
        public sales_mvcContext(DbContextOptions<sales_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
