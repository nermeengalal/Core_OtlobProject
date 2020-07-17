using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Models
{
    public class Card
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        public int RestID { get; set; }

        [ForeignKey("RestID")]
        public virtual Restaurant Restaurant { get; set; }

        [Display(Name ="Meal Name")]
        public int MealID { get; set; }

        [ForeignKey("MealID")]
        public virtual MealsInMenu Meal { get; set; }


        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Comments { get; set; }

    }
}
