using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            List<Trip> tripList = new List<Trip>();
            User.User loggedInUser = GetLoggedUser();
            if (loggedInUser != null)
            {
                if (user.isFriendWith(loggedInUser))
                {
                    tripList = TripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }

        protected virtual User.User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        protected virtual List<Trip> TripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

    }
}
