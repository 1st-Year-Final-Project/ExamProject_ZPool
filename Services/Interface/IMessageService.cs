using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;

namespace ZPool.Services.Interface
{
    public interface IMessageService
    {
        void CreateMessage(Message message);
        IEnumerable<Message> GetSentMessage(int userId);
        IEnumerable<Message> GetReceivedMessages(int userId);
        List<Message> GetMessagesByUserId(int userId);
    }
}
