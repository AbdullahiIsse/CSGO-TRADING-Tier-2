using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IUserData
    {

        Task<IList<userAccount>> getAllUsers();



    }
}