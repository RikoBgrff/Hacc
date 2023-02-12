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
    public class BlogManager : IBlogService
    {
        readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdaet(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll().ToList();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}
