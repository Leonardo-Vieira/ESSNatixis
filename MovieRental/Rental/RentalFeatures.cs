using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;
using System.Threading.Tasks;

namespace MovieRental.Rental
{
    public class RentalFeatures : IRentalFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public RentalFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        //TODO: make me async :(
        public async Task<Rental> Save(Rental rental)
        {
            _movieRentalDb.Rentals.Add(rental);
            await _movieRentalDb.SaveChangesAsync();
            return rental;
        }

        //TODO: finish this method and create an endpoint for it
        public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
        {
            var customerId = _movieRentalDb.Customer.FirstOrDefault(x => x.Name == customerName)?.Id;
            if (customerId.HasValue)
            {
                var result = _movieRentalDb.Rentals.Where(x => x.CustomerId == customerId);
            }
            return [];
        }

        public async Task<bool> RentMovie(Rental rental)
        {
            try
            {
                var paymentMethods = new Dictionary<string, IPaymentMethod>
                {
                    { "MbWay", new MbWayProvider() },
                    { "PayPal", new PayPalProvider() }
                };

                if (rental != null && paymentMethods.TryGetValue(rental.PaymentMethod, out var paymentMethod) && paymentMethod != null)
                {
                    bool result = await paymentMethod.Pay(rental.Price);
                    if (result)
                    {
                        await _movieRentalDb.SaveChangesAsync();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
