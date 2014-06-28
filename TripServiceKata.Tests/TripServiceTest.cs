using NUnit.Framework;
using NUnit.Framework.Constraints;

using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    public class TripServiceTest
    {
        
        [Test]
        [ExpectedException("TripServiceKata.Exception.UserNotLoggedInException")]
        public void it_should_validate_the_user_is_logged_in()
        {
            TripServiceForTests tripService = new TripServiceForTests();
            tripService.GetTripsByUser(null);
        }

        private class TripServiceForTests : TripService
        {
            protected override User.User GetLoggedUser()
            {
                return null;
            }
        }
    }

}
