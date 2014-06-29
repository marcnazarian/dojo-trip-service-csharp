using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TripServiceKata.Trip
{
    public interface ITripDAO
    {
        List<Trip> TripsByUser(User.User user);
    }
}
