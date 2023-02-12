using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract.BlogAbstract
{
    public interface IImageService
    {
      public void ImageAdd(Image image);
      public void ImageDelete(Image image);
      public void ImageUpdate(Image image);
      public List<Image> GetAll();
      public Image GetById(int id);
    }
}
