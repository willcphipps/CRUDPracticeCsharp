using System.ComponentModel.DataAnnotations;
using System;

namespace CRUDible.Models {
    public class Dish {
        [Key]
        public int DishId { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        public string ChefName { get; set; }
        [Required]
        public int Tastiness { get; set; }
        [Required]
        public int Calories { get; set; }
        public string description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}