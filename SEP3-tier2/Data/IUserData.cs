using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IUserData
    {

        Task<IList<User>> getAllUsers();
        void AddUser(User user);
        void RemoveUser(long id);
        Task<User> ValidateUser(string userName, string Password);

    }
}