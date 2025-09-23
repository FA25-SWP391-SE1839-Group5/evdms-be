using EVDMS.Common.Utils;
using Xunit;

namespace EVDMS.Common.Tests.Utils
{
    public class PasswordHasherTests
    {
        [Trait("Category", "Unit")]
        [Fact]
        public void HashPassword_ShouldReturnDifferentHash_ForSamePassword()
        {
            var password = "TestPassword123!";

            var hash1 = PasswordHasher.HashPassword(password);
            var hash2 = PasswordHasher.HashPassword(password);

            Assert.NotEqual(hash1, hash2); // BCrypt should generate different hashes due to salt
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void VerifyPassword_ShouldReturnTrue_ForCorrectPassword()
        {
            var password = "MySecretPassword!";
            var hash = PasswordHasher.HashPassword(password);

            var result = PasswordHasher.VerifyPassword(password, hash);

            Assert.True(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void VerifyPassword_ShouldReturnFalse_ForIncorrectPassword()
        {
            var password = "CorrectPassword";
            var wrongPassword = "WrongPassword";
            var hash = PasswordHasher.HashPassword(password);

            var result = PasswordHasher.VerifyPassword(wrongPassword, hash);

            Assert.False(result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void HashPassword_ShouldThrowArgumentNullException_ForNullPassword()
        {
            Assert.Throws<ArgumentNullException>(() => PasswordHasher.HashPassword(null));
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void VerifyPassword_ShouldThrowArgumentNullException_ForNullArguments()
        {
            var hash = PasswordHasher.HashPassword("password");

            Assert.Throws<ArgumentNullException>(() => PasswordHasher.VerifyPassword(null, hash));
            Assert.Throws<ArgumentNullException>(() =>
                PasswordHasher.VerifyPassword("password", null)
            );
        }
    }
}
