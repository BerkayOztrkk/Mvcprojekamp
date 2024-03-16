using BusinessLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminService _adminDal;
        private EFAdminDal eFAdminDal;

        public AdminManager(IAdminService adminDal)
        {
            _adminDal=adminDal;
        }

        public AdminManager(EFAdminDal eFAdminDal)
        {
            this.eFAdminDal=eFAdminDal;
        }

        public void AdminAdd(Admin category)
        {
            throw new NotImplementedException();
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAdmins()
        {
            return _adminDal.GetAdmins();
        }

    

        Admin IAdminService.Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
