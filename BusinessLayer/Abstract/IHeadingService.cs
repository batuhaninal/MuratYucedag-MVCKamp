using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        Heading GetById(int id);
        void Add(Heading entity);
        void Delete(Heading entity);
        void Update(Heading entity);
    }
}
