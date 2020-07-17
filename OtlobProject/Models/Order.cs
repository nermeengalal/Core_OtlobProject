using OtlobProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Models
{
    public class Order
    {
        public Order()
        {
            Payment = PaymentMethod.Cash;
        }
        public int ID { get; set; }

        public TimeSpan EstimatedDeliveryTime { get; set; }

        [CreditCard]
        public string CreditNumber { get; set; }

        public TimeSpan OrderTime { get; set; } 

        public int SubTotalPrice { get; set; }

        public int TotalPrice { get; set; }

        public PaymentMethod Payment { get; set; }

        public int AddressID { get; set; }

        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }

        public string CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual ApplicationUser Customer { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }
    public enum PaymentMethod
    {
        Cash=0,
        Credit=1
    }
}
