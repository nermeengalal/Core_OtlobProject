using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class MealsServices : IService<MealsInMenu>
    {
        private readonly DBContext context;

        public MealsServices(DBContext context)
        {
            this.context = context;
        }

        public int Add(MealsInMenu Model)
        {
            context.Meals.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {

            context.Meals.Remove(context.Meals.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<MealsInMenu> GetAll()
        {
            return context.Meals.ToList();
        }

        public MealsInMenu GetDetails(int id)
        {
            return context.Meals.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, MealsInMenu Model)
        {
            MealsInMenu Meal = context.Meals.FirstOrDefault(s => s.ID == id);
            Meal.Name = Model.Name;
            Meal.Logo = Model.Logo;
            Meal.Description = Model.Description;
            Meal.Price = Model.Price;
            Meal.Cat = Model.Cat;
            Meal.IsMeal = Model.IsMeal;

            context.SaveChanges();
            return 1;
        }
    }
}
