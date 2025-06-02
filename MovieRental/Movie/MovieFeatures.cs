using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public Movie Save(Movie movie)
		{
			try
			{
                _movieRentalDb.Movies.Add(movie);
                _movieRentalDb.SaveChanges();
                return movie;
            }
			catch (Exception e)
			{
				throw e;
			}			
		}

		// TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
		public List<Movie> GetAll()
		{
			try
			{
                //return _movieRentalDb.Movies.Take(100).ToList();
                return _movieRentalDb.Movies.ToList();
            }
			catch (Exception e)
			{
				throw e;
			}            
		}
	}
}
