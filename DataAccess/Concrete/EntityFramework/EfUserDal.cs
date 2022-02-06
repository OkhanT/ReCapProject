using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<UserOperationClaimDetailDto> GetUserOperationClaimDetail(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from o in context.OperationClaims
                             join u in context.UserOperationClaims
                             on o.Id equals u.OperationClaimId
                             join us in context.Users
                             on u.UserId equals us.Id
                             where u.UserId == user.Id
                             select (new UserOperationClaimDetailDto
                             {
                                 Id=o.Id,
                                 UserName = us.FirstName,
                                 UserLastName = us.LastName,
                                 Email = us.Email,
                                 OperationClaimName = o.OperationClaimName
                             });
                return result.ToList();
            }
        }
    }
}
