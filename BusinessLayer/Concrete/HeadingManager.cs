using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading entity)
        {
            _headingDal.Insert(entity);
        }

        public void Delete(Heading entity)
        {
            _headingDal.Update(entity);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.List();
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
