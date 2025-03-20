using core.ValueObjects;

namespace UnitTests
{
    public class TelephoneTest
    {
        TestProprieties proprieties = new TestProprieties();

        [Fact]
        public void TelephoneValid()
        {
            //Arrange //Act //Assert

            Assert.True(proprieties.telephoneValid.Valid);
            Assert.True(proprieties.telephoneValid.Errors.Count() == 0);

        }

        [Fact]
        public void ReturnErrorWhenDDDIsNullorEmpyt()
        {
            //Arrange
            var telephone = new Telephone(null, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("DDD is required"));
        }

        [Fact]
        public void ReturnErrorWhenDDDQuantityCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterQuantityInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain 02 characters"));
        }

        [Fact]
        public void ReturnErrorWhenDDDCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain only numbers"));
        }

        [Fact]
        public void ReturnErrorWhenPhoneNumberIsNullorEmpyt()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddValid, null);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("Phone number is required"));
        }

        [Fact]
        public void ReturnErrorWhenPhoneNumberQuantityCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddValid, proprieties.phoneNumberCharacterQuantityInvalid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The phone number must contain between 8 and 9 characters and only numbers"));
        }

        [Fact]
        public void ReturnErrorWhenPhoneNumberCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddValid, proprieties.phoneNumberCharacterInvalid);

            //Act and Assert

            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The phone number must contain between 8 and 9 characters and only numbers"));
        }

    }
}