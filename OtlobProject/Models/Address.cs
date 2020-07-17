using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Models
{
    public class Address
    {
        public Address()
        {
            this.AppartmentNO = null;
            this.FloorNO = null;
            this.BuildingNO = null;
        }
        public int ID { get; set; }

        [Required]
        public int? AppartmentNO { get; set; }

        [Required]
        public int? FloorNO { get; set; }

        [Required]
        public int? BuildingNO { get; set; }

        [Required]
        public string StreetName { get; set; }

        public int AreaID { get; set; }

        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }

    }
}
