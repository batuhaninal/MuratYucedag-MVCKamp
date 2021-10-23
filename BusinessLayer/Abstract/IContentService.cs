using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByWriter(int id);
        List<Content> GetAllByHeadingId(int id);
        Content GetById(int id);
        void Add(Content entity);
        void Update(Content entity);
        void Delete(Content entity);
    }
}
