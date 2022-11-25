using GroceryListBackEnd.Interface;
using GroceryListBackEnd.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GroceryListBackEnd.Service
{
    public class GroceryItemService : IGroceryItemService
    {
        private readonly GroceryItemContext context;

        public GroceryItemService()
        {
            context = new GroceryItemContext();
        }
        public IQueryable<GroceryItem> Get(string? keywords)
        {
            var query = context.GroceryItems.AsQueryable().OrderByDescending(x => x.ItemId);
            if (!string.IsNullOrEmpty(keywords))
            {
                query = query.Where(x => x.ItemName.ToLower().Contains(keywords.ToLower()) ).OrderByDescending(x => x.ItemId);
            }
            return query;
        }

        public GroceryItem GetById(int id)
        {
            var Item = context.GroceryItems.SingleOrDefault( x=> x.ItemId == id);
            return Item;
        }

        public int Post(GroceryItem itemNew)
        {
            itemNew.IsDone = false;
            if(string.IsNullOrEmpty(itemNew.ItemName)) return 0;
            context.GroceryItems.Add(itemNew);
            context.SaveChanges();
            return itemNew.ItemId;
        }

        public int Put(GroceryItem itemUpdate)
        {
            if (string.IsNullOrEmpty(itemUpdate.ItemName)) return 0;
            var itemCheck = context.GroceryItems.SingleOrDefault( x=> x.ItemId == itemUpdate.ItemId);
            if (itemCheck == null) return 0;
            itemCheck.ItemName = itemUpdate.ItemName;
            itemCheck.IsDone = itemUpdate.IsDone;
            context.GroceryItems.Update(itemCheck);
            context.SaveChanges();
            return 1;
        }
        public int Delete(int id)
        {
            var itemDelete = context.GroceryItems.SingleOrDefault(x => x.ItemId == id);
            if (itemDelete == null) return 0;
            context.GroceryItems.Remove(itemDelete);
            context.SaveChanges();
            return 1;
        }
    }
}
