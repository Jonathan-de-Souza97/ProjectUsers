using core.Entity;
using ProjectUsers.Tests;

namespace UnitTests
{
    [Trait("Category","UnitTest")]
    public class UserTest
    {
        TestProprieties proprieties = new TestProprieties();


        [Trait("Item","User")]
        [Fact]
        public void UserValid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Valid);
            Assert.True(user.Errors.Count() == 0);
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenUserNameIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameNull, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The name is required"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenUserNameIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameInvalid, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.False(user.Valid);
            Assert.Contains(user.Errors, e => e.Equals("The name must contain a maximum of 50 characters"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenEmailIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailNull, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The e-mail is required"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenEmailIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailInvalid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("This e-mail is invalid"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenPasswordIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordNull, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The password is required"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenPasswordIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordInvalid, proprieties.telephoneValid);

            //Act Assert
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("Password must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be at least 8 characters long"));
        }

        [Trait("Item","User")]
        [Fact]
        public void ReturnErrorWhenTelephoneIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordValid, null);

            //Act Assert
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("Telephone is required"));
        }
    }
}