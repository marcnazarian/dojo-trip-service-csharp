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
        
        private static User.User loggedInUser;
        
        [Test]
        [ExpectedException("TripServiceKata.Exception.UserNotLoggedInException")]
        public void it_should_validate_the_user_is_logged_in()
        {
            TripServiceForTests tripService = new TripServiceForTests();

            loggedInUser = GUEST;

            tripService.GetTripsByUser(A_USER);
        }

        private class TripServiceForTests : TripService
        {
            protected override User.User GetLoggedUser()
            {
                return loggedInUser;
            }
        }
    }

}
