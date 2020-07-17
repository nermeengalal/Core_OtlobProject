using OtlobProject.Data;
using OtlobProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public class AddressService : IService<Address>
    {
        private readonly DBContext context;

        public AddressService(DBContext context)
        {
            this.context = context;
        }

        public int Add(Address Model)
        {
            context.Addresses.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.Addresses.Remove(context.Addresses.FirstOrDefault(s => s.ID == id));
            context.SaveChanges();
            return 1;
        }

        public List<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        public Address GetDetails(int id)
        {
            return context.Addresses.FirstOrDefault(s => s.ID == id);
        }

        public int Update(int id, Address Model)
        {
            Address Add = context.Addresses.FirstOrDefault(s => s.ID == id);
            Add.AppartmentNO = Model.AppartmentNO;
            Add.FloorNO = Model.FloorNO;
            Add.BuildingNO = Model.BuildingNO;
            Add.StreetName = Model.StreetName;
            Add.AreaID = Model.AreaID;
            Add.Area = Model.Area;
           
            context.SaveChanges();
            return 1;
        }
    }
}
