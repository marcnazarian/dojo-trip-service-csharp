using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TripServiceKata.User
{
    public class UserBuilder
    {
        private User[] friends = { };
        private Trip.Trip[] trips = { };

        public static UserBuilder aUser()
        {
            return new UserBuilder();
        }

        public UserBuilder friendWith(params User[] friends)
        {
            this.friends = friends;
            return this;
        }

        public UserBuilder withTrips(params Trip.Trip[] trips)
        {
            this.trips = trips;
            return this;
        }

        public User build()
        {
            User user = new User();
            addFriendsTo(user);
            addTripsTo(user);
            return user;
        }

        private void addFriendsTo(User user)
        {
            foreach (User friend in this.friends)
            {
                user.AddFriend(friend);
            }
        }

        private void addTripsTo(User user)
        {
            foreach (Trip.Trip trip in this.trips)
            {
                user.AddTrip(trip);
            }
        }

    }
}
