using core.ValueObjects;

namespace ProjectUsers.Tests
{
    public class TelephoneTest
    {
        TestProprieties proprieties = new TestProprieties();

        [Fact]
        public void ReturnErrorWhenDDDIsNullorEmpyt()
        {
            //Arrange
            var telephone = new Telephone(null,proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("DDD is required"));
        }

        [Fact]
        public void ReturnErrorWhenQuantityCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterQuantityInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain 02 characters"));
        }

        [Fact]
        public void ReturnErrorWhenCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain only numbers"));
        }
    }
}