using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDestiny.Models.Cars
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
        public int Number { get; set; }
        public List<Component> Components { get; set; }
        public CarType CarType { get; set; }

        public Car(string Name, string Model, DateTime PublishDate, int Number, CarType CarType)
        {
            this.Name = Name;
            this.Model = Model;
            this.Number = Number;

            this.PublishDate = PublishDate;
            this.CarType = CarType;
        }

    }

}