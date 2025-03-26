using core.Validators;
using core.ValueObjects;

namespace core.Entity
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Telephone Telephone{ get; private set; }
        public DateTime CreationDate { get; private set; }

        public User(string name, string email, string password, Telephone telephone)
        {
            Name = name;
            Email = email;
            Password = password;
            Telephone = telephone;
            CreationDate = DateTime.UtcNow.AddHours(-3);

            Validate(this, new UserValidator());
        }
    }
}