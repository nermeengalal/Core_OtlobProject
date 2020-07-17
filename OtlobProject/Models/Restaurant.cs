using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            DeliveryFee = null;
        }
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression("^01[0-9]{9}", ErrorMessage = "Mobile Number is not valid")]
        [Required]
        public string Mobile { get; set; }

        [RegularExpression("[0-9]{5}", ErrorMessage = "HotLine Number is not valid")]
        public string HotLine { get; set; }

        public TimeSpan MaxEstimatedDeliveryTime { get; set; }

        [Required]
        public string Logo { get; set; }

        public TimeSpan WorkingFrom { get; set; }

        public TimeSpan WorkingTo { get; set; }

        [Required]
        public int? DeliveryFee { get; set; }


        [Required]
        [Display(Name ="Area")]
        public int AreaID { get; set; }

        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }

        public virtual ICollection<MealsInMenu> Meals { get; set; }
    }

}
