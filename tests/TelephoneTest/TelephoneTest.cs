using core.ValueObjects;

namespace ProjectTest.Tests
{
    public class TelephoneTest
    {
        [Fact]
        public void ReturnErrorWhenDDDIsNullorEmpyt()
        {
            //Arrange
            var phoneNumber = "912345678";
            var telephone = new Telephone(null,phoneNumber);

            //Act and Assert
            Assert.True(telephone.Invalid);
            Assert.Contains(telephone.Errors, e => e.Equals("DDD is required"));
        }
    }
}