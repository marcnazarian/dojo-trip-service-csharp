using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            if (GetLoggedUser() == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.isFriendWith(GetLoggedUser()) 
                ? TripsByUser(user)
                : new List<Trip>();
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
