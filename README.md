# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue.
 - what was causing the issue was the AddSingleton that should be change for AddScoped because it's a service that is trying to access the database

 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
- The difference is that if the method takes too much time, it will freeze the application, while if we use async, it will let the thread free, just awaiting that particular response, making the app more responsive

 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
- it is a danger method to execute because it's returning all the movies from the database so if we had 1000000000000 movies it would try to retive them all, what would make the APP crash

 * No exceptions are being caught in this api, how would you deal with these exceptions?
- By using the "try, catch" when we call an outside source for example the DbContext or any API
