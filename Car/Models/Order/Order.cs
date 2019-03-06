using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDestiny.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartDate{ get; set; }
        public Car OrderedCar { get; set; }
        public string BreakInfo { get; set; }
        public string Recomendation { get; set; }
        public User Master { get; set; }
        public Component Component { get; set; }

    }

}