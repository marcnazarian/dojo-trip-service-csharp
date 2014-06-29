using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    public class TripServiceTest
    {
        public const User.User GUEST = null;
        public readonly User.User A_USER = new User.User();
        public readonly User.User REGISTERED_USER = new User.User();
        public readonly User.User ANOTHER_USER = new User.User();

        public readonly Trip.Trip BRASIL = new Trip.Trip();
        public readonly Trip.Trip LONDON = new Trip.Trip();

        private static User.User loggedInUser;
        private TripServiceForTests tripService;

        [SetUp]
        public void setUp()
        {
            tripService = new TripServiceForTests();
        }

        [Test]
        [ExpectedException("TripServiceKata.Exception.UserNotLoggedInException")]
        public void it_should_validate_the_user_is_logged_in()
        {
            loggedInUser = GUEST;

            tripService.GetTripsByUser(A_USER);
        }

        [Test]
        public void it_should_not_return_any_trips_when_users_are_not_friends()
        {
            loggedInUser = REGISTERED_USER;
            
            User.User stranger = new User.User();
            stranger.AddFriend(ANOTHER_USER);
            stranger.AddTrip(BRASIL);

            List<Trip.Trip> trips = tripService.GetTripsByUser(stranger);

            Assert.That(trips, Is.Empty);
        }

        [Test]
        public void it_should_return_trips_when_users_are_friends()
        {
            loggedInUser = REGISTERED_USER;

            User.User friend = new User.User();
            friend.AddFriend(ANOTHER_USER);
            friend.AddFriend(REGISTERED_USER);
            friend.AddTrip(BRASIL);
            friend.AddTrip(LONDON);

            List<Trip.Trip> trips = tripService.GetTripsByUser(friend);

            Assert.That(trips.Count, Is.EqualTo(2));
        }

        private class TripServiceForTests : TripService
        {
            protected override User.User GetLoggedUser()
            {
                return loggedInUser;
            }

            protected override List<Trip.Trip> TripsByUser(User.User user)
            {
                return user.Trips();
            }
        }
    }

}
