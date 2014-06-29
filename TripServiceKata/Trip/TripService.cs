using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            User.User loggedInUser = GetLoggedUser();
            if (loggedInUser == null)
            {
                throw new UserNotLoggedInException();
            }


            if (user.isFriendWith(loggedInUser))
            {
                return TripsByUser(user);
            }
            else
            {
                return new List<Trip>();
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
