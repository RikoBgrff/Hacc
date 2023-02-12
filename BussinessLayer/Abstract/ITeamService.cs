using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ITeamService
    {
        void TeamAdd(Team team);
        void TeamRemove(Team team);
        void TeamUpdate(Team team);
        List<Team> GetList();
        Team GetById(int id);
    }
}
