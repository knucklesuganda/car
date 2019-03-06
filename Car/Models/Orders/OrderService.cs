using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CarsDestiny.Models.Cars;
using LiteDB;

namespace CarsDestiny.Models.Orders
{
    public class OrderService
    {
        public string DbName { get; set; }
        /*public List<Order> GetAllOrders(out string message)
        {

            try
            {

                using (LiteDatabase db = new LiteDatabase(DbName))
                {
                    message = "";
                    //return db.GetCollection<Order>("Order");
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }

        }*/

        public string CreateOrder(DateTime startDate, Car car,
            string breakInfo, string recomendation, User master, Component comp)
        {

            try
            {
                Order order = new Order(startDate, car, breakInfo, recomendation, master, comp);

                using(LiteDatabase db = new LiteDatabase(DbName))
                {

                    var orders = db.GetCollection<Order>("Orders");
                    orders.Insert(order);

                }

                return "All ok!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string DeleteOrder(int Id)
        {

            try
            {

                using (LiteDatabase db = new LiteDatabase(DbName))
                {

                    var orders = db.GetCollection<Order>("Orders");
                    orders.Delete(Id);

                }

                return "Order deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public Order FindOrder(int Id, out string message) {

            try
            {
                Order order = null;

                using (LiteDatabase db = new LiteDatabase(DbName))
                {
                    order = db.GetCollection<Order>("Orders").Find(x => x.Id == Id).FirstOrDefault();
                }

                message = "";
                return order;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }

        }

    }

}