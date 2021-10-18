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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public void Delete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId==id);
        }

        public void Update(Content entity)
        {
            _contentDal.Update(entity);
        }
    }
}
