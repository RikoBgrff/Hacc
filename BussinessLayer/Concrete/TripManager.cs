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
    public class TripManager : ITripService
    {

        public readonly ITripDal _tripdal;

        public TripManager(ITripDal tripdal)
        {
            _tripdal = tripdal;
        }

        public Trip GetById(int id)
        {
            return _tripdal.GetById(id);
        }

        public List<Trip> GetList()
        {
            return _tripdal.GetAll().ToList();
        }

        public void TripAdd(Trip team)
        {
            _tripdal.Insert(team);
        }

        public void TripRemove(Trip trip)
        {
            _tripdal.Delete(trip);
        }

        public void TripUpdate(Trip trip)
        {
            _tripdal.Update(trip);
        }
    }
}
