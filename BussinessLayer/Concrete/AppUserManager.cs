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
    public class AppUserManager : IAppUserService
    {
        readonly IAppUserDal userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void AppUserAdd(AppUser user)
        {
            userDal.Insert(user);
        }

        public void AppUserRemove(AppUser user)
        {
            userDal.Update(user);
        }

        public void AppUserUpdate(AppUser user)
        {
            userDal.Update(user);
        }

        public AppUser GetById(int id)
        {
            return userDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return userDal.GetAll();
        }
    }
}
