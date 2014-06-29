using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using TripServiceKata.Trip;
using TripServiceKata.User;

using NSubstitute;

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

        private TripService tripService;

        private ITripDAO tripDAO;

        [SetUp]
        public void setUp()
        {
            tripDAO = Substitute.For<ITripDAO>();
            tripService = new TripService(tripDAO);
        }

        [Test]
        [ExpectedException("TripServiceKata.Exception.UserNotLoggedInException")]
        public void it_should_validate_the_user_is_logged_in()
        {
            tripService.GetTripsByUser(A_USER, GUEST);
        }

        [Test]
        public void it_should_not_return_any_trips_when_users_are_not_friends()
        {
            User.User stranger = UserBuilder.aUser()
                .friendWith(ANOTHER_USER)
                .withTrips(BRASIL)
                .build();
            tripDAO.TripsByUser(stranger).Returns(stranger.Trips());

            List<Trip.Trip> trips = tripService.GetTripsByUser(stranger, REGISTERED_USER);

            Assert.That(trips, Is.Empty);
        }

        [Test]
        public void it_should_return_trips_when_users_are_friends()
        {
            User.User friend = UserBuilder.aUser()
                .friendWith(ANOTHER_USER, REGISTERED_USER)
                .withTrips(BRASIL, LONDON)
                .build();
            tripDAO.TripsByUser(friend).Returns(friend.Trips());

            List<Trip.Trip> trips = tripService.GetTripsByUser(friend, REGISTERED_USER);

            Assert.That(trips.Count, Is.EqualTo(2));
        }

    }

}
