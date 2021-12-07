using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IPaymentData
    {
        void AddPayment(CreditCard creditCard);

        Task<CreditCard> GetPaymentById(long id);

        Task<CreditCard> GetPaymentByName(string name);
    }
}