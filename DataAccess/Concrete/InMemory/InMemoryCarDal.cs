using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Brand> _brand = new List<Brand> 
        { 
            new Brand{BrandId = 1 , BrandName = "BMW"},
            new Brand{BrandId = 2 , BrandName = "Bugatti"},
            new Brand{BrandId = 3 , BrandName = "Mercedes"},
            new Brand{BrandId = 4 , BrandName = "Aston Martin"}
        };

        List<Color> _color = new List<Color>()
        {
            new Color{ColorId = 1 , ColorName = "Kırmızı"},
            new Color{ColorId = 2 , ColorName = "Beyaz"},
            new Color{ColorId = 3 , ColorName = "Siyah"},
            new Color{ColorId = 4 , ColorName = "Sarı"},
            new Color{ColorId = 5 , ColorName = "Turuncu"}
        };


        List<Car> _car = new List<Car>
        {
            
            new Car{CarId = 1 , BrandId = 1 , CarName = "i8" , ColorId = 2 , ModelYear = 2010 , DailyPrice = 200000 , Description = "280 bin kilometrede, memurdan satılık." },
            new Car{CarId = 2 , BrandId = 1 , CarName = "i3" , ColorId = 4 , ModelYear = 2015 , DailyPrice = 150000 , Description = "100bin kilometrede, öğretmen kullanmıştır." },
            new Car{CarId = 3 , BrandId = 2 , CarName = "Chiron" , ColorId = 3 , ModelYear = 2018 , DailyPrice = 175000 , Description = "Kusursuz araç..."},
            new Car{CarId = 4 , BrandId = 4 , CarName = "Rapide" , ColorId = 5 , ModelYear = 2018 , DailyPrice = 183000 , Description = "Taksi çıkması...."},
            new Car{CarId = 5 , BrandId = 3 , CarName = "EQS" , ColorId = 3 , ModelYear = 2017 , DailyPrice = 182000 , Description = "Hasar kayıtlı araç..."}
        };

      
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _car.SingleOrDefault(c=>c.CarId==car.CarId);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car;
            //throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _car.Where(c=>(c.BrandId == brandId)).ToList();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
