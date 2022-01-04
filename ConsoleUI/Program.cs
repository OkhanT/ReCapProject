using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICarService carservice = new CarManager(new EfCarDal());
            carservice.Add(new Car() { });

            foreach (var car in carservice.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
        }
    }
}
