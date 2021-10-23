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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public List<Message> GetAllInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetAllSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
