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
    public class AppRoleManager : IAppRoleService
    {
        readonly IAppRoleDal roleDal;

        public AppRoleManager(IAppRoleDal roleDal)
        {
            this.roleDal = roleDal;
        }

        public void AppRoleAdd(AppRole role)
        {
            roleDal.Insert(role);
        }

        public void AppRoleRemove(AppRole role)
        {
            roleDal.Delete(role);
        }

        public void AppRoleUpdate(AppRole role)
        {
            roleDal.Update(role);
        }

        public AppRole GetById(int id)
        {
            return roleDal.GetById(id);
        }

        public List<AppRole> GetList()
        {
            return roleDal.GetAll();
        }
    }
}
