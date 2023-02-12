using BussinessLayer.Abstract.BlogAbstract;
using DataAccessLayer.Abstract.BlogDal;
using EntityLayer.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Concrete.BlogConcrete
{
    public class PostManager : IPostService
    {
        readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> GetList()
        {
            return _postDal.GetAll()
                .Include(p => p.Images)
                .Include(t=>t.Tags)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _postDal.GetById(id);
        }

        public void PostAdd(Post post)
        {
            _postDal.Insert(post);
        }

        public void PostDelete(Post post)
        {
            _postDal.Delete(post);
        }

        public void PostUpdate(Post post)
        {
            _postDal.Update(post);
        }
    }
}
