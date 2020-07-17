using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.ModelViews
{
    public class MealModelView
    {
        public MealModelView()
        {
            Cat = Category.Sandwich;
            IsMeal = false;
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public Category Cat { get; set; }

        public bool IsMeal { get; set; }

        public int QuantityNeeded { get; set; }

        public int TotalPrice { get; set; }
    }

    public enum Category
    {
        Combo = 0,
        Sandwich = 1
    }
}
