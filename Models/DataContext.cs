using Microsoft.EntityFrameworkCore;

namespace mayorista_el_brujo.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

     
    }
}
