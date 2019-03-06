using CarsDestiny.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDestiny.Models.Orders
{
    public class Order
    {
        public Order(DateTime startDate, Car car, string breakInfo, string recomendation, User master, Component comp)
        {
            StartDate = startDate;
            OrderedCar = car;

            BreakInfo = breakInfo;
            Recomendation = recomendation;

            Master = master;
            Component = comp;
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public Car OrderedCar { get; set; }
        public string BreakInfo { get; set; }

        public string Recomendation { get; set; }
        public User Master { get; set; }

        public Component Component { get; set; }
    }

}