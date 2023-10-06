namespace Currencies.DAL.Entities
{
    public class Currency
    {
        public string Id { get; set; }
        public string NumCode { get; set; } 
        public string CharCode { get; set; } 
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal VunitRate { get; set; }

        public Currency(string id, string numCode, string charCode, string name) 
        {
            Id = id;
            NumCode = numCode;
            CharCode = charCode;
            Name = name;
        }
    }
}
