using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IItemService
    {
        void ItemAdd(Item item);
        void ItemRemove(Item item);
        void ItemUpdate(Item item);
        List<Item> GetList();
        Item GetById(int id);
    }
}
