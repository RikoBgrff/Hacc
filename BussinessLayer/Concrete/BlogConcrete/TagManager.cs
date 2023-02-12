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
    public class TagManager : ITagService
    {
        readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public List<Tag> GetAll()
        {
            return _tagDal.GetAll().ToList();
        }

        public Tag GetById(int id)
        {
            return _tagDal.GetById(id);
        }

        public void TagAdd(Tag tag)
        {
            _tagDal.Insert(tag);
        }

        public void TagDelete(Tag tag)
        {
            _tagDal.Delete(tag);
        }

        public void TagUpdate(Tag tag)
        {
            _tagDal.Update(tag);
        }
    }
}
