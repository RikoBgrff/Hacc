using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract.BlogAbstract
{
    public interface IPostService
    {
      public  void PostAdd(Post post);
      public  void PostDelete(Post post);
      public  void PostUpdate(Post post);
      public  List<Post> GetList();
      public  Post GetById(int id);
    }
}
