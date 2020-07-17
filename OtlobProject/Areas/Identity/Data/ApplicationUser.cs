using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OtlobProject.Models;

namespace OtlobProject.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int? RestID { get; set; }

        [ForeignKey("RestID"),]
        public virtual Restaurant Restaurant { get; set; }

        public int? AreaID { get; set; }

        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
