using DataAccessLayer.Abstract.BlogDal;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Blog;

namespace DataAccessLayer.EntityFramework.BlogEntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {

    }
}
