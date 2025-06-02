using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Rental.Rental rental)
        {
	        return Ok(_features.Save(rental));
        }

        [HttpGet]
        public IEnumerable<Rental.Rental> Get([FromBody] string customerName)
        {
	        return _features.GetRentalsByCustomerName(customerName);
        }

        [HttpPost("RentMovie")]
        public bool RentMovie([FromBody] Rental.Rental rental)
        {
	        return _features.RentMovie(rental).Result;
        }
	}
}
