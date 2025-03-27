using Core.Validators;
using Core.ValueObjects;

namespace Core.Entity
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Telephone Telephone{ get; private set; }
        public DateTime CreateAt { get; private set; }

        public User(string name, string email, string password, Telephone telephone)
        {
            Name = name;
            Email = email;
            Password = password;
            Telephone = telephone;
            Validate(this, new UserValidator());
        }
    }
}