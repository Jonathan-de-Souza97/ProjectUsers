namespace core.ValueObjects
{
    public class Telephone
    {
        public string DDD { get; set; }

        public string NumeroTelefone { get; set; }


        public Telephone(string ddd, string numeroTelefone)
        {
            DDD = ddd;
            NumeroTelefone = numeroTelefone;
        }
    }
}