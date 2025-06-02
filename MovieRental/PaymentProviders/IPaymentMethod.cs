namespace MovieRental.PaymentProviders
{
    public interface IPaymentMethod
    {
        Task<bool> Pay(double price);
    }
}
