namespace Application.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public TelephoneDTO Telephone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}