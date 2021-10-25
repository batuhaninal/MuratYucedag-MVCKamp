using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService 
    {
        List<Admin> GetAll();
        void Add(Admin entity);
        Admin GetById(int id);
        void Delete(Admin entity);
        void Update(Admin entity);
    }
}
