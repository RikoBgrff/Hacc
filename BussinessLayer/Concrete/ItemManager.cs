using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ItemManager : IItemService
    {
        readonly IItemDal itemDal;

        public ItemManager(IItemDal itemDal)
        {
            this.itemDal = itemDal;
        }

        public Item GetById(int id)
        {
            return itemDal.GetById(id);
        }

        public List<Item> GetList()
        {
            return itemDal.GetAll().ToList();
        }

        public void ItemAdd(Item item)
        {
            itemDal.Insert(item);
        }

        public void ItemRemove(Item item)
        {
            itemDal.Delete(item);
        }

        public void ItemUpdate(Item item)
        {
            itemDal.Update(item);
        }
    }
}
