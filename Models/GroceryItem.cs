using System.ComponentModel.DataAnnotations;

namespace GroceryListBackEnd.Models
{
    public class GroceryItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        public bool IsDone { get;set; }
    }
}
