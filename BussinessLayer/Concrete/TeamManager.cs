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
    public class TeamManager : ITeamService
    {
        readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public Team GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public List<Team> GetList()
        {
            return _teamDal.GetAll().ToList();
        }

        public void TeamAdd(Team team)
        {
            _teamDal.Insert(team);
        }

        public void TeamRemove(Team team)
        {
            _teamDal.Delete(team);
        }

        public void TeamUpdate(Team team)
        {
            _teamDal.Update(team);
        }
    }
}

