﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();
        void AdminAdd(Admin admin);
        Admin Getbyid(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
