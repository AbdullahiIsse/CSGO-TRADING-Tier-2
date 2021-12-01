using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IWalletData
    {
        Task<IList<Wallet>> getAllWallets();
        Task<Wallet> getWalletById(long id); 
    }
}