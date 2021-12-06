using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IWalletData
    {

        Task<long> SumOfPrice(long id);

        void AddWallet(Wallet wallet);

        Task<Wallet> UpdatePriceByPaymentId(Wallet wallet, long id);




    }
}