using core.ValueObjects;

namespace ProjectUsers.Tests
{
    [Trait("Category", "UnitTests")]
    public class TelephoneTest
    {
        TestProprieties proprieties = new TestProprieties();

        [Trait("Item","Telephone")]
        public void TelephoneValid()
        {
            //Arrange //Act //Assert

            Assert.True(proprieties.telephoneValid.Valid);
            Assert.True(proprieties.telephoneValid.Errors.Count() == 0);
            
        }

        [Trait("Item","Telephone")]
        public void ReturnErrorWhenDDDIsNullorEmpyt()
        {
            //Arrange
            var telephone = new Telephone(null,proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("DDD is required"));
        }

        [Trait("Item","Telephone")]
        public void ReturnErrorWhenDDDQuantityCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterQuantityInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain 02 characters"));
        }

        [Trait("Item","Telephone")]
        public void ReturnErrorWhenDDDCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddCharacterInvalid, proprieties.phoneNumberValid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The DDD must contain only numbers"));
        }
        
        [Trait("Item","Telephone")]
        public void ReturnErrorWhenPhoneNumberIsNullorEmpyt()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddValid,null);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("Phone number is required"));
        }

        [Trait("Item","Telephone")]
        public void ReturnErrorWhenPhoneNumberQuantityCharactersIsInvalid()
        {
            //Arrange
            var telephone = new Telephone(proprieties.dddValid, proprieties.phoneNumberCharacterQuantityInvalid);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("The phone number must contain between 8 and 9 characters and only numbers"));
        }

        [Trait("Item","Telephone")]
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