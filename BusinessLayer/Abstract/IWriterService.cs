using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        void Add(Writer entity);
        void Delete(Writer entity);
        void Update(Writer entity);
        Writer GetById(int id);
    }
}
