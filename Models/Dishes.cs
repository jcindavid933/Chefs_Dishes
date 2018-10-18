using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefs_dishes.Models
{
    public class Dishes
    {
        [Key]
        public int DishesId{get;set;}
        [Required]
        [MinLength(2)]
        public string Name {get; set;}
        [Required]
        [Range(1,10000)]
        public int Calories {get;set;}
        [Required]
        public string Description{get;set;}
        [Required]
        [Range(1,5)]
        public int Tastiness{get;set;}
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;
        [Required]
        public int ChefId{get;set;}
        [ForeignKey("ChefId")]
        public Chef Creator {get;set;}
    }
}