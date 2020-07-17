using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class AreaServices : IService<Area>
    {
        private readonly DBContext context;

        public AreaServices(DBContext context)
        {
            this.context = context;
        }

        public int Add(Area Model)
        {
            context.Areas.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.Areas.Remove(context.Areas.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<Area> GetAll()
        {
            return context.Areas.ToList();
        }

        public Area GetDetails(int id)
        {
            return context.Areas.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, Area Model)
        {
            Area area = context.Areas.FirstOrDefault(s => s.ID == id);
            area.CityName = Model.CityName;
            area.SubArea = Model.SubArea;
           
            context.SaveChanges();
            return 1;
        }
    }
}
