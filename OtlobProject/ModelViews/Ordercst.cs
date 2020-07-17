using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.ModelViews
{
    public class Ordercst
    {
        public Ordercst()
        {
            IsDone = false;
        }
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public bool IsDone { get; set; }
    }
}
