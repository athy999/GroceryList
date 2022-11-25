using GroceryListBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryListBackEnd
{
    public class GroceryItemContext : DbContext
    {
        public DbSet<GroceryItem> GroceryItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\HUYEN;Database=Grocery;Trusted_Connection=True");
        }
    }
}
