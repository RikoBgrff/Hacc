using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract.BlogAbstract
{
    public interface  IBlogService
    {
     public void BlogAdd(Blog blog);
     public void BlogDelete(Blog blog);
     public void BlogUpdaet(Blog blog);
     public List<Blog> GetAll();
     public Blog GetById(int id);
    }
}
