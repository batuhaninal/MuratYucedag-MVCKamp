using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category entity);
        Category GetById(int id);
        void Delete(Category entity);
        void Update(Category entity);

    }
}
