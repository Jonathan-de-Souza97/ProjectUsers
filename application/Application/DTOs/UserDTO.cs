namespace Application.DTOs
{
    public class UserDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TelephoneDTO Telephone { get; set; }
    }
}