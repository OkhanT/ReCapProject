using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Entities;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByFirstName(string firstName);
        IDataResult<List<User>> GetByLastName(string lastName);
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<UserOperationClaimDetailDto>> GetClaims(User user);

        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

    }
}
