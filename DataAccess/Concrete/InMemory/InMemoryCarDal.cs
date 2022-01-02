using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car = new List<Car>
        {
            new Car{Id=1,BrandId=1,BrandName="BMW",ColorId=1,ModelYear=2010,DailyPrice=200000,Description="280 bin kilometrede, memurdan satılık."},
            new Car{Id=1, BrandId=1,BrandName="Mercedes",ColorId=1,ModelYear=2015,DailyPrice=150000,Description="100bin kilometrede, öğretmen kullanmıştır." },
            new Car{Id=2,BrandId=1,BrandName="Volvo",ColorId=2,ModelYear=2018,DailyPrice=175000,Description="Kusursuz araç..."},
            new Car{Id=2,BrandId=2,BrandName="Skoda",ColorId=2,ModelYear=2018,DailyPrice=183000,Description="Taksi çıkması...."},
            new Car{Id=3,BrandId=3,BrandName="Mercedes",ColorId=3,ModelYear=2017,DailyPrice=182000,Description="Hasar kayıtlı araç..."}
        };
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _car.SingleOrDefault(c=>c.Id==car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int brandId)
        {
            return _car.Where(c=>(c.BrandId == brandId)).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
