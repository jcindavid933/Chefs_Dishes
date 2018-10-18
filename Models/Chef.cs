using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefs_dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId{get;set;}
        [Required]
        [MinLength(2)]
        public string first_name {get; set;}
        [Required]
        [MinLength(2)]
        public string last_name {get; set;}
        [Required]
        public DateTime DOB {get;set;}
        [Range(18,100, ErrorMessage="You must be at least 18 years of age!")]
        public int Age
        {
            get{
                return DateTime.Now.Year - DOB.Year;
            }
        }
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;
        public List<Dishes> Dishes {get;set;}
    }
}