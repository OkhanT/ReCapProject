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
            //InMemoryTest();
            //ColorAddTest(new Color { ColorName="Mavi"});
            //ColorGetAllTest();
            //ColorGetByIdTest();
            //ColorUpdateTest();
            //ColorDeleteTest();

            //BrandAddTest(new Brand {BrandName= "Volkswagen" }) ;
            //BrandGetAllTest();
            //BrandGetByIdTest();
            //BrandUpdateTest();
            //BrandDeleteTest();

            //CarAddTest(new Car() {BrandId = 2, CarName = "A3", ColorId = 4, ModelYear = 2015, DailyPrice = 1200, Description = "Motor Hacmi: 1401 - 1600 cm3 / Vites: Otomatik / Yakıt: Dizel / Kasa Tipi: Sedan" });
            //CarGetAllTest();
            //CarGetCarsByBrandIdTest();
            //CarGetCarsByColorIdTest();
            //CarUpdateTest();
            //CarDeleteTest();
            //CarGetDetailDtosTest();
            //CarGetByIdTest();

            /*UserAddTest(new User
            {
                FirstName = "Enes",
                LastName = "Öztürk",
                Email = "ozturk@gmail.com",
                Password = "23243324"
            });*/

            //UserGetAllTest();
            //UserUpdateTest();
            //UserDeleteTest();
            //CustomerAddTest();
            //CustomerUpdateTest();
            //CustomerDeleteTest();
            //CustomerGetDetailDtoTest();

            //RentalAddTest();
            //RentalGetRentalDetailDtoTest();

            IUserService userService = new UserManager(new EfUserDal());
            var result = userService.GetByFirstName("Okhan");
            foreach ( var user in result.Data)
            {
                Console.WriteLine(user.FirstName + " / " + user.Email);
            }

        }

        private static void RentalGetRentalDetailDtoTest()
        {
            RentalManegar rentalManegar = new RentalManegar(new EfRentalDal());
            var result = rentalManegar.GetRentalDetailDto();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CompanyName + " / " + rental.FirstName + " " + rental.LastName + " / " + rental.CarName + " / " + rental.BrandName + " / " + rental.ColorName + " / " + "Günlük Fiyat: " + rental.DailyPrice + " / " + " Kiralama tarihi: " + rental.RentDate + " / " + "Teslim Tarihi: " + rental.ReturnDate + " / " + rental.Description);
            }
            Console.WriteLine(result.Message);
        }

        private static void RentalAddTest()
        {
            RentalManegar rentalManegar = new RentalManegar(new EfRentalDal());
            var result = rentalManegar.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2022,01,10),
                ReturnDate = new DateTime(2022, 01, 11),
            });
            Console.WriteLine(result.Message);
        }

        private static void CustomerGetDetailDtoTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetailDto();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName + " : " + customer.FirstName);
            }
            Console.WriteLine(result.Message);
        }

        private static void CustomerDeleteTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Delete(new Customer { CustomerId = 5 });
            Console.WriteLine(result.Message);
        }

        private static void CustomerUpdateTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Update(new Customer
            {
                CustomerId = 2,
                UserId = 1,
                CompanyName = "Tan-Car"
            });
            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "Öz-Car"
            });
            Console.WriteLine(result.Message);
        }

        private static void UserDeleteTest()
        {
            UserManager userMananger = new UserManager(new EfUserDal());
            var result = userMananger.Delete(new User { UserId = 3 });
            Console.WriteLine(result.Message);
        }

        private static void UserUpdateTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Update(new User { UserId = 3, FirstName = "Aziz", LastName = "Ödemiş", Email = "ödemis@gmail.com", Password = "1232123" });
            Console.WriteLine(result.Message);
        }

        private static void UserGetAllTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Email);
            }
            Console.WriteLine(result.Message);
        }

        private static void UserAddTest(User _user)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(_user);
            Console.WriteLine(result.Message);
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(4);
            Console.WriteLine(result.Data.CarName + " / " + result.Message);
        }

        private static void CarGetDetailDtosTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetDetailDtos();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + " / " + car.CarName + " / " + car.ColorName);
            }
            Console.WriteLine(result.Message);
        }

        private static void CarDeleteTest()
        {
            CarManager carManager6 = new CarManager(new EfCarDal());
            var deletedCar = new Car 
            { 
                BrandId = 2, 
                CarName = "A3", 
                ColorId = 4, 
                ModelYear = 2015, 
                DailyPrice = 1200, 
                Description = "Motor Hacmi: 1401 - 1600 cm3 / Vites: Otomatik / Yakıt: Dizel / Kasa Tipi: Sedan" 
            };
            var result = carManager6.Delete(deletedCar);
            Console.WriteLine(result.Message);
        }

        private static void CarUpdateTest()
        {
            //Tüm car listesi güncellendi!!!
            CarManager carManager5 = new CarManager(new EfCarDal());
            var updatedCar = new Car 
            { 
                CarId = 3, 
                BrandId = 2, 
                CarName = "A8", 
                ColorId = 3, 
                ModelYear = 2015, 
                DailyPrice = 2500, 
                Description = "Motor Hacmi: 2501 - 3000 cm3 / Vites: Otomatik / Yakıt: Benzin / Kasa Tipi: Sedan" 
            };
            var result = carManager5.Update(updatedCar);
            Console.WriteLine(result.Message);
            
        }

        private static void CarGetCarsByColorIdTest()
        {
            CarManager carManager4 = new CarManager(new EfCarDal());
            var result = carManager4.GetCarsByColorId(3);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine(result.Message);
        }

        private static void CarGetCarsByBrandIdTest()
        {
            CarManager carManager3 = new CarManager(new EfCarDal());
            var result = carManager3.GetCarsByBrandId(1);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine(result.Message);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            var result = carManager2.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarAddTest(Car _car)
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.Add(_car);
            Console.WriteLine(result.Message);
            
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager5 = new BrandManager(new EfBrandDal());
            var deletedBrand = new Brand 
            { 
                BrandId = 4, 
                BrandName = "Aston Martin" 
            };
            var result = brandManager5.Delete(deletedBrand);
            Console.WriteLine(result.Message);
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager4 = new BrandManager(new EfBrandDal());
            var updatedBrand = new Brand 
            { 
                BrandId = 2, 
                BrandName = "Audi" 
            };
            var result = brandManager4.Update(updatedBrand);
            Console.WriteLine(result.Message);
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager3 = new BrandManager(new EfBrandDal());
            var result = brandManager3.GetById(3);
            Console.WriteLine(result.Data.BrandName);
            Console.WriteLine(result.Message);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager2 = new BrandManager(new EfBrandDal());
            var result = brandManager2.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            };
            Console.WriteLine(result.Message);
        }

        private static void BrandAddTest(Brand brand)
        {
            BrandManager brandManager1 = new BrandManager(new EfBrandDal());
            var result = brandManager1.Add(brand);
            Console.WriteLine(result.Message);
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager5 = new ColorManager(new EfColorDal());
            var deletedColor = new Color 
            { 
                ColorId = 2, 
                ColorName = "Beyaz" 
            };
            var result = colorManager5.Delete(deletedColor);
            Console.WriteLine(result.Message);
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager4 = new ColorManager(new EfColorDal());
            var updatedColor = new Color 
            { 
                ColorId = 1, 
                ColorName = "Kırmızı" 
            };
            var result = colorManager4.Update(updatedColor);
            Console.WriteLine(result.Message);
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager3 = new ColorManager(new EfColorDal());

            var result = colorManager3.GetById(3);
            Console.WriteLine(result.Data.ColorName);
            Console.WriteLine(result.Message);
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager2 = new ColorManager(new EfColorDal());
            var result = colorManager2.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine(result.Message);

        }

        private static void ColorAddTest(Color colors)
        {
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            var result = colorManager1.Add(colors);
            Console.WriteLine(result.Message);

        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
