using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class CardService : IService<Card>
    {
        private readonly DBContext context;

        public CardService(DBContext context)
        {
            this.context = context;
        }

        public int Add(Card Model)
        {
            context.Cards.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.Cards.Remove(context.Cards.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<Card> GetAll()
        {
            return context.Cards.ToList();
        }

        public Card GetDetails(int id)
        {
            return context.Cards.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, Card Model)
        {
            Card card = context.Cards.FirstOrDefault(s => s.ID == id);
            card.Order = Model.Order;
            card.OrderID = Model.OrderID;
            card.RestID = Model.RestID;
            card.Restaurant = Model.Restaurant;
            card.Meal = Model.Meal;
            card.MealID = Model.MealID;
            card.Quantity = Model.Quantity;
            card.Price = Model.Price;
            card.Comments = Model.Comments;
           
            context.SaveChanges();
            return 1;
        }
    }
}
