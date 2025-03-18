using core.Entity;
using core.Validators;

namespace core.ValueObjects
{
    public class Telephone : EntityBase
    {
        public string? DDD { get; set; }

        public string NumeroTelefone { get; set; }


        public Telephone(string ddd, string numeroTelefone)
        {
            DDD = ddd;
            NumeroTelefone = numeroTelefone;

            Validate(this, new TelephoneValidator());
        }
    }
}