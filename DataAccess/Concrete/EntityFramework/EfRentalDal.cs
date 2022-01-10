using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars
                             on r.CarId equals car.CarId
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join user in context.Users
                             on c.UserId equals user.UserId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new RentalDetailDto 
                             { 
                                 RentalId = r.RentalId,
                                 CompanyName = c.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CarName =car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 Description = car.Description
                             
                             };

                return result.ToList(); 

            }
        }
    }
}
