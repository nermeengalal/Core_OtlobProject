using Microsoft.AspNetCore.Http;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.ModelViews
{
    public class MealViewModel
    {
        public MealViewModel()
        {
            Cat = Category.Sandwich;
            IsMeal = false;
        }

        public enum Category
        {
            Combo = 0,
            Sandwich = 1
        }
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public IFormFile Logo { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public Category Cat { get; set; }

        public bool IsMeal { get; set; }

        [Display(Name = "Restaurant")]
        public int RestID { get; set; }

        [ForeignKey("RestID")]
        public virtual Restaurant Restaurant { get; set; }
    }

}

