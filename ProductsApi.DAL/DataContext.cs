using Microsoft.EntityFrameworkCore;
using ProductsApi.DAL.Models;

namespace ProductsApi.DAL
{
    public class DataContext: DbContext
    {
         public virtual DbSet<Product> SP_Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
