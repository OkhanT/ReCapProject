using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICarService carservice = new CarManager(new InMemoryCarDal());

            foreach (var car in carservice.GetAll())
            {
                Console.WriteLine(car.BrandName);
            }
        }
    }
}
