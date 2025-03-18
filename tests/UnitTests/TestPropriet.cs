using core.ValueObjects;

namespace ProjectUsers.Tests
{
    public class TestPropriet
    {
        public string nameNull { get; set; } = null;
        public string emailNull { get; set; } = null;
        public string passwordNull { get; set; } = null;
        public string telephoneNull { get; set; } = null;
        public string dddNull { get; set; } = null;
        public string phoneNumberNull { get; set; } = null;

        public string nameInvalid { get; set; } = "This name is invalid hasdijsaiosjdaoisjdasihsadipjpojdsapi";
        public string emailInvalid { get; set; } = "JonathanEmailInvalid";
        public string passwordInvalid { get; set; } = "invalid";
        public string dddCharacterQuantityInvalid { get; set; } = "111";
        public string dddCharacterInvalid { get; set; } = "1a";
        public string phoneNumberCharacterQuantityInvalid { get; set; } = "231";
        public string phoneNumberCharacterInvalid { get; set; } = "91234567a";

        public string nameValid { get; set; } = "Name Valid";
        public string emailValid { get; set; } = "Jonathan@gmail.com";
        public string passwordValid { get; set; } = "Valid@Password123";
        public string phoneNumberValid {get; set; } = "942536442";
        public Telephone telephoneValid { get; set; } = new Telephone("11", "942536442");
    }
}