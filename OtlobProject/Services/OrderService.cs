using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class OrderService : IService<Order>
    {
        private readonly DBContext context;

        public OrderService(DBContext context)
        {
            this.context = context;
        }

        public int Add(Order Model)
        {
            context.orders.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.orders.Remove(context.orders.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<Order> GetAll()
        {
            return context.orders.ToList();
        }

        public Order GetDetails(int id)
        {
            return context.orders.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, Order Model)
        {
            Order order = context.orders.FirstOrDefault(s => s.ID == id);
            order.EstimatedDeliveryTime = Model.EstimatedDeliveryTime;
            order.CreditNumber = Model.CreditNumber;
            order.OrderTime = Model.OrderTime;
            order.SubTotalPrice = Model.SubTotalPrice;
            order.TotalPrice = Model.TotalPrice;
            order.Payment = Model.Payment;
            order.Cards = Model.Cards;
            order.Customer = Model.Customer;
            order.CustomerID = Model.CustomerID;
            order.Address = Model.Address;
            order.AddressID = Model.AddressID;
            context.SaveChanges();
            return 1;
        }
    }
}
