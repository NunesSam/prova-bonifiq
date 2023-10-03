using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
	public class OrderService
	{
        private readonly Dictionary<string, IPaymentMethod> _paymentMethods;

        public OrderService(IEnumerable<IPaymentMethod> paymentMethods)
        {
            _paymentMethods = paymentMethods.ToDictionary(p => p.GetType().Name.ToLower());
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (_paymentMethods.TryGetValue(paymentMethod.ToLower(), out var selectedPaymentMethod))
            {
                return await selectedPaymentMethod.ProcessPayment(paymentValue, customerId);
            }

            // Tratar caso o método de pagamento não seja reconhecido
            throw new ArgumentException("Método de pagamento não reconhecido", nameof(paymentMethod));
        }
       
	}
}
