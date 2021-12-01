using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IChatData
    {
        Task<IList<Chat>> getAllChat();
        Task<Chat> getChatByID(long user_id);
        
        void AddChat(Chat chat);
    }
}