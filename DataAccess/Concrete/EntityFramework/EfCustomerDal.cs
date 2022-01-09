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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDtos()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new CustomerDetailDto {CustomerId=c.CustomerId,CompanyName=c.CompanyName,FirstName=u.FirstName,LastName=u.LastName,Email=u.Email,Password=u.Password };

                return result.ToList();
            }
        }
    }
}
