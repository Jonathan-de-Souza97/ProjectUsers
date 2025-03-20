using core.Entity;
using core.Validators;

namespace core.ValueObjects
{
    public class Telephone : EntityBase
    {
        public string? DDD { get; set; }

        public string PhoneNumber { get; set; }


        public Telephone(string ddd, string phoneNumber)
        {
            DDD = ddd;
            PhoneNumber = phoneNumber;

            Validate(this, new TelephoneValidator());
        }
    }
}