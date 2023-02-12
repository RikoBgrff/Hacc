using BussinessLayer.Abstract.BlogAbstract;
using DataAccessLayer.Abstract.BlogDal;
using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete.BlogConcrete
{
    public class ImageManager : IImageService
    {
        readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public List<Image> GetAll()
        {
            return _imageDal.GetAll().ToList();
        }

        public Image GetById(int id)
        {
            return _imageDal.GetById(id);
        }

        public void ImageAdd(Image image)
        {
            _imageDal.Insert(image);
        }

        public void ImageDelete(Image image)
        {
            _imageDal.Delete(image);
        }

        public void ImageUpdate(Image image)
        {
            _imageDal.Update(image);
        }
    }
}
