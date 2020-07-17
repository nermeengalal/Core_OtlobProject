using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.ModelViews
{
    public class CardOrder
    {
        public int OrderId { get; set; }
        public string CusName{ get; set; }
        public int Totalprice { get; set; }
        public List<Card> cards { get; set; }
        public List<string> MealName { get; set; }
    }
}
