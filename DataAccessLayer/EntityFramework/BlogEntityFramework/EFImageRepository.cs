using DataAccessLayer.Abstract.BlogDal;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework.BlogEntityFramework
{
    public class EFImageRepository:GenericRepository<Image>,IImageDal
    {
    }
}
