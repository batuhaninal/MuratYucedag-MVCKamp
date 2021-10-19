using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox();
        List<Message> GetAllSendbox();
        Message GetById(int id);
        void Add(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
    }
}
