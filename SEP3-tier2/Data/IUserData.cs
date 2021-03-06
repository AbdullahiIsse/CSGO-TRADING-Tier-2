using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IUserData
    {

        Task<IList<User>> getAllUsers();
        Task<User> AddUser(User user);
        Task RemoveUser(long id);
        Task<User> ValidateUser(string userName, string Password);
        
        Task<User> getUserByID(long id);

        Task<User> UpdateUser(User user, long id);
        
        
        Task<User> UserBySaleOfferId(long id);

    }
}