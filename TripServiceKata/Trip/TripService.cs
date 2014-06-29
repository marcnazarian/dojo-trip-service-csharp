using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user, User.User loggedInUser)
        {
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.isFriendWith(loggedInUser) 
                ? TripsByUser(user)
                : new List<Trip>();
        }

        protected virtual List<Trip> TripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

    }
}
