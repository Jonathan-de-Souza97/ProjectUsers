using Application.DTOs;

namespace Application.Commands
{
    public class AddUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TelephoneDTO Telephone { get; set; }
    }
}