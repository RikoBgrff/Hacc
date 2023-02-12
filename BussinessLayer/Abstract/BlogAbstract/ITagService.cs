using EntityLayer.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract.BlogAbstract
{
    public interface ITagService
    {
        public void TagAdd(Tag tag);
        public void TagDelete(Tag tag);
        public void TagUpdate(Tag tag);
        public List<Tag> GetAll();
        public Tag GetById(int id);

    }
}
