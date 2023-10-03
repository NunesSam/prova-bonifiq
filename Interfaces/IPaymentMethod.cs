using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IPaymentMethod
    {
        Task<Order> ProcessPayment(decimal paymentValue, int customerId);
    }
}
