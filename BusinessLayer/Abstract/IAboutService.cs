﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        About GetById(int id);
        void Add(About entity);
        void Update(About entity);
        void Delete(About entity);
    }
}
