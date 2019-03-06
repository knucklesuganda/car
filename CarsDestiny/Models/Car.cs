using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDestiny.Models
{
    public enum CarType
    {
        Light, Rover, Dias
    }

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime PublishDate { get; set; }
        public CarType CarType { get; set; }

        public Car(string Name, string Model, DateTime PublishDate, CarType carType)
        {
            this.Name = Name;
            this.Model = Model;

            this.PublishDate = PublishDate;
            this.CarType = CarType;
        }

    }

}