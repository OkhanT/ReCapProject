using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManegar : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManegar(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [SecuredOperation("rental.getall")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CarId==carId),Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CustomerId==customerId),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId),Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDto(),Messages.RentalDetailDtoListed);
        }

        public IResult Update(Rental rental)
        {
            var result = rental.ReturnDate;
            if (result == new DateTime())
            {                
                return new ErrorResult(Messages.RentalReturnDate);
            }
            else
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }           
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Rental rental)
        {
            _rentalDal.Update(rental);
            _rentalDal.Add(rental); 
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
