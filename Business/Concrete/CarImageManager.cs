using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
                
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            if (carImage.ImagePath == "" | carImage.ImagePath == null)
            {
                carImage.ImagePath = "DefaultImage.jpg";
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
            
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImage(carImage.CarImageId));
            if (result != null)
            {
                return new ErrorResult(Messages.ImageIdNotFound);
            }
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {                   
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result,Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {                       
            var resultList = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(resultList, Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            var result = _carImageDal.Get(c=>c.CarImageId==imageId);
            return new SuccessDataResult<CarImage>(result,Messages.CarImageListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var filePath = PathConstants.ImagesPath + carImage.ImagePath;
            var result = _fileHelper.Update(file,filePath,PathConstants.ImagesPath);
            carImage.ImagePath = result;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carImageId)
        {
            var result = _carImageDal.GetAll(c=>c.CarImageId == carImageId);
            if(result.Count !> 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }           
    }
}
