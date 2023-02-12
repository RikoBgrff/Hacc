using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ITripService
    {
        void TripAdd(Trip team);
        void TripRemove(Trip trip);
        void TripUpdate(Trip trip);
        List<Trip> GetList();
        Trip GetById(int id);
    }
}
