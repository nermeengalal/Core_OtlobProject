using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class ResautrantService : IService<Restaurant>
    {
        private readonly DBContext context;

        public ResautrantService(DBContext context)
        {
            this.context = context;
        }

        public int Add(Restaurant Model)
        {
            context.Restaurants.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.Restaurants.Remove(context.Restaurants.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<Restaurant> GetAll()
        {
            return context.Restaurants.ToList();
        }

        public Restaurant GetDetails(int id)
        {
            return context.Restaurants.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, Restaurant Model)
        {
            Restaurant Rest = context.Restaurants.FirstOrDefault(s => s.ID == id);
            Rest.Name = Model.Name;
            Rest.Logo = Model.Logo;
            Rest.MaxEstimatedDeliveryTime = Model.MaxEstimatedDeliveryTime;
            Rest.Meals = Model.Meals;
            Rest.AreaID = Model.AreaID;
            Rest.DeliveryFee = Model.DeliveryFee;
            Rest.HotLine = Model.HotLine;
            Rest.Mobile = Model.Mobile;
            Rest.WorkingFrom = Model.WorkingFrom;
            Rest.WorkingTo = Model.WorkingTo;
         
            context.SaveChanges();
            return 1;
        }
    }
}
