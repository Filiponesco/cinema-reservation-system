using System;
using Xunit;

namespace cinema_reservation_system_individual_auth.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CeasarCispher_EncipherTest1234WithKey13_ReturnsEncryptedPasswordGrfg1234()
        {
            // arange
            int key = 13;
            string password = "Test1234";

            // act
            string result = CaesarCipher.Encipher(password, key);

            // assert
            Assert.Equal("Grfg1234", result);
        }
    }
}
