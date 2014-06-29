using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {

        private ITripDAO tripDAO;

        public TripService(ITripDAO tripDAO)
        {
            this.tripDAO = tripDAO;
        }

        public List<Trip> GetTripsByUser(User.User user, User.User loggedInUser)
        {
            validateLoggedInUser(loggedInUser);

            return user.isFriendWith(loggedInUser) 
                ? TripsByUser(user)
                : NoTrips();
        }


        private static void validateLoggedInUser(User.User loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }
        }

        protected virtual List<Trip> TripsByUser(User.User user)
        {
            return tripDAO.TripsByUser(user);
        }

        private static List<Trip> NoTrips()
        {
            return new List<Trip>();
        }

    }
}
