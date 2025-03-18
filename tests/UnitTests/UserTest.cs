using core.Entity;

namespace ProjectUsers.Tests
{
    public class UserTest
    {
        TestProprieties proprieties = new TestProprieties();

        [Fact]
        public void UserValid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Valid);
            Assert.True(user.Errors.Count() == 0);
        }

        [Fact]
        public void ReturnErrorWhenUserNameIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameNull, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The name is required"));
        }

        [Fact]
        public void ReturnErrorWhenUserNameIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameInvalid, proprieties.emailValid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.False(user.Valid);
            Assert.Contains(user.Errors, e => e.Equals("The name must contain a maximum of 50 characters"));
        }

        [Fact]
        public void ReturnErrorWhenEmailIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailNull, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The e-mail is required"));
        }

        [Fact]
        public void ReturnErrorWhenEmailIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailInvalid, proprieties.passwordValid, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("This e-mail is invalid"));
        }

        [Fact]
        public void ReturnErrorWhenPasswordIsNullorEmpyt()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordNull, proprieties.telephoneValid);

            // Act Assert 
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("The password is required"));
        }

        [Fact]
        public void ReturnErrorWhenPasswordIsInvalid()
        {
            //Arrange
            var user = new User(proprieties.nameValid, proprieties.emailValid, proprieties.passwordInvalid, proprieties.telephoneValid);

            //Act Assert
            Assert.True(user.Invalid);
            Assert.Contains(user.Errors, e => e.Equals("Password must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be at least 8 characters long"));
        }

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