using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Models
{
    public class Area
    {
        public int ID { get; set; }

        [Required]
        public string CityName { get; set; }

        public string SubArea { get; set; }
    }
}
