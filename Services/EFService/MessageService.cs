using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService
{
    public class MessageService : IMessageService
    {
        private AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public IEnumerable<Message> GetSentMessage(int userId)
        {
            var sent = _context.Messages.AsNoTracking()
                .Where(m => m.SenderId == userId);
            return sent;
        }

        public IEnumerable<Message> GetReceivedMessages(int userId)
        {
            return _context.Messages.AsNoTracking()
                .Where(m => m.ReceiverId == userId);
        }

        public void SetStatusToRead(int id)
        {
            Message message = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                message.IsRead = true;
                _context.Update(message);
            }
                
            
        }


    }
}
