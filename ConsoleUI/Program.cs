using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {



            //List<Color> colors = new List<Color>()
            //{
            //    new Color{ColorId = 1 , ColorName = "Kırmızı"},
            //    new Color{ColorId = 2 , ColorName = "Beyaz"},     //Database'den SİLİNDİ!!
            //    new Color{ColorId = 3 , ColorName = "Siyah"},
            //    new Color{ColorId = 4 , ColorName = "Sarı"},
            //    new Color{ColorId = 5 , ColorName = "Turuncu"}
            //};

            //List<Brand> brands = new List<Brand>
            //{
            //    new Brand{BrandId = 1 , BrandName = "BMW"},
            //    new Brand{BrandId = 2 , BrandName = "Bugatti"},
            //    new Brand{BrandId = 3 , BrandName = "Mercedes"},
            //    new Brand{BrandId = 4 , BrandName = "Aston Martin"}   //Database'den SİLİNDİ!!
            //};

            //    List<Car> _car = new List<Car>
            //{

            //    new Car{CarId = 1 , BrandId = 1 , CarName = "i8" , ColorId = 1 , ModelYear = 2010 , DailyPrice = 200000 , Description = "280 bin kilometrede, memurdan satılık." },
            //    new Car{CarId = 2 , BrandId = 1 , CarName = "i3" , ColorId = 4 , ModelYear = 2015 , DailyPrice = 150000 , Description = "100bin kilometrede, öğretmen kullanmıştır." }, Database'den SİLİNDİ!!
            //    new Car{CarId = 3 , BrandId = 2 , CarName = "Chiron" , ColorId = 3 , ModelYear = 2018 , DailyPrice = 175000 , Description = "Kusursuz araç..."},
            //    new Car{CarId = 4 , BrandId = 3 , CarName = "Rapide" , ColorId = 5 , ModelYear = 2018 , DailyPrice = 183000 , Description = "Taksi çıkması...."},
            //    new Car{CarId = 5 , BrandId = 3 , CarName = "EQS" , ColorId = 3 , ModelYear = 2017 , DailyPrice = 182000 , Description = "Hasar kayıtlı araç..."}
            //}; 

            //InMemoryTest();
            //ColorAddTest(colors);
            //ColorGetAllTest();
            //ColorGetByIdTest();
            //ColorUpdateTest();
            //ColorDeleteTest();

            //BrandAddTest(brands);
            //BrandGetAllTest();
            //BrandGetByIdTest();
            //BrandUpdateTest();
            //BrandDeleteTest();

            //CarAddTest(_car);
            //CarGetAllTest();
            //CarGetCarsByBrandIdTest();
            //CarGetCarsByColorIdTest();
            //CarUpdateTest();
            //CarDeleteTest();

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetDetailDtos();
            foreach (var car in result )
            {
                Console.WriteLine(car.BrandName + " / " + car.CarName + " / " + car.ColorName);
            }




        }

        private static void CarDeleteTest()
        {
            CarManager carManager6 = new CarManager(new EfCarDal());
            var deletedCar = new Car { CarId = 2, BrandId = 1, CarName = "i3", ColorId = 4, ModelYear = 2015, DailyPrice = 150000, Description = "100bin kilometrede, öğretmen kullanmıştır." };
            carManager6.Delete(deletedCar);
        }

        private static void CarUpdateTest()
        {
            CarManager carManager5 = new CarManager(new EfCarDal());
            var updatedCar = new Car { CarId = 5, BrandId = 3, CarName = "SLS AMG", ColorId = 4, ModelYear = 2020, DailyPrice = 432000, Description = "THY personelinden satılık...." };
            carManager5.Update(updatedCar);
        }

        private static void CarGetCarsByColorIdTest()
        {
            CarManager carManager4 = new CarManager(new EfCarDal());
            foreach (var car in carManager4.GetCarsByColorId(3))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetCarsByBrandIdTest()
        {
            CarManager carManager3 = new CarManager(new EfCarDal());
            foreach (var car in carManager3.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetAllTest()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarAddTest(List<Car> _car)
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in _car)
            {
                carManager1.Add(car);
            }
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager5 = new BrandManager(new EfBrandDal());
            var deletedBrand = new Brand { BrandId = 4, BrandName = "Aston Martin" };
            brandManager5.Delete(deletedBrand);
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager4 = new BrandManager(new EfBrandDal());
            var updatedBrand = new Brand { BrandId = 2, BrandName = "Tofaş" };
            brandManager4.Update(updatedBrand);
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager3 = new BrandManager(new EfBrandDal());
            var result = brandManager3.GetById(3);
            Console.WriteLine(result.BrandName);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager2 = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager2.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            };
        }

        private static void BrandAddTest(List<Brand> brands)
        {
            BrandManager brandManager1 = new BrandManager(new EfBrandDal());
            foreach (var brand in brands)
            {
                brandManager1.Add(brand);
            }
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager5 = new ColorManager(new EfColorDal());
            var deletedColor = new Color { ColorId = 2, ColorName = "Beyaz" };
            colorManager5.Delete(deletedColor);
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager4 = new ColorManager(new EfColorDal());
            var updatedColor = new Color { ColorId = 1, ColorName = "Mavi" };
            colorManager4.Update(updatedColor);
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager3 = new ColorManager(new EfColorDal());

            var result = colorManager3.GetById(3);
            Console.WriteLine(result.ColorName);
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager2 = new ColorManager(new EfColorDal());

            foreach (var color in colorManager2.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ColorAddTest(List<Color> colors)
        {
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            foreach (var color in colors)
            {
                colorManager1.Add(color);
            }
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
