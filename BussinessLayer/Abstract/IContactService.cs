﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContactService
    {
        void ContactAdd(Contact contact);
        void ContactRemove(Contact contact);
        void ContactUpdate(Contact contact);
        List<Contact> GetList();
        Contact GetById(int id);
    }
}
