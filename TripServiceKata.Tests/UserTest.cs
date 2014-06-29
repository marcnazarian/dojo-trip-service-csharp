using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using NUnit.Framework.Constraints;

using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    class UserTest
    {
        public readonly User.User BOB = new User.User();
        public readonly User.User ALEX = new User.User();

        [Test]
        public void it_should_inform_when_users_are_not_friends() {
            User.User user = UserBuilder.aUser()
                                .friendWith(BOB)
                                .build();

            Assert.That(user.isFriendWith(ALEX), Is.EqualTo(false));
        }

        [Test]
        public void it_should_inform_when_users_are_friends()
        {
            User.User user = UserBuilder.aUser()
                                .friendWith(BOB, ALEX)
                                .build();

            Assert.That(user.isFriendWith(ALEX), Is.EqualTo(true));
        }

    }
}
