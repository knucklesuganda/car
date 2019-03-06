using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiteDB;

namespace CarsDestiny.Models.Cars
{
    public class CarService
    {
        public string dbName { get; set; }
        public string AddCar(string Name, string Model, int Number, DateTime PublishDate, CarType carType)
        {

            try
            {
                Car car = new Car(Name, Model, PublishDate, Number, carType);

                using (LiteDatabase db = new LiteDatabase(dbName))
                {

                    var cars = db.GetCollection<Car>("Cars");
                    cars.Insert(car);

                }

                return "Car added!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string RemoveCar(int Id)
        {

            try
            {
                using(LiteDatabase db = new LiteDatabase(dbName))
                {

                    var car = db.GetCollection<Car>("Cars");
                    car.Delete(Id);

                }

                return "Car removed!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public Car FindCarByNumber(int Number, out string message)
        {
            Car car = null;

            try
            {

                using (LiteDatabase db = new LiteDatabase(dbName))
                {

                    var cars = db.GetCollection<Car>("Cars");
                    IEnumerable<Car> results = cars.Find(x => x.Number.Equals(Number));

                    if (results.Any())
                    {
                        message = "";
                        return results.FirstOrDefault();
                    }
                    else
                    {
                        message = "There is no such car";
                        return car;
                    }

                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return car;
            }

        }
        public Car FindCarByModel(string Model, out string message)
        {
            Car car = null;

            try
            {

                using (LiteDatabase db = new LiteDatabase(dbName))
                {

                    var cars = db.GetCollection<Car>("Cars");
                    IEnumerable<Car> results = cars.Find(x => x.Model.Equals(Model));

                    if (results.Any())
                    {
                        message = "";
                        return results.FirstOrDefault();
                    }
                    else
                    {
                        message = "There is no such car";
                        return car;
                    }

                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return car;
            }

        }
        public string AddComponent(int Id, Component component)
        {

            try
            {

                using (LiteDatabase db = new LiteDatabase(dbName))
                {

                    var cars = db.GetCollection<Car>("Cars");
                    Car results = cars.Find(x => x.Id.Equals(Id)).FirstOrDefault();

                    results.Components.Add(component);
                    cars.Update(results);

                }

                return "Component added!";
            }
            catch (Exception ex){return ex.Message;}

        }
    }

}