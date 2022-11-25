using GroceryListBackEnd.Models;

namespace GroceryListBackEnd.Interface
{
    public interface IGroceryItemService
    {
        public GroceryItem GetById (int id);
        public IQueryable<GroceryItem> Get (string? keywords);
        public int Post(GroceryItem itemNew);
        public int Put(GroceryItem itemUpdate);
        public int Delete(int id);
    }
}
