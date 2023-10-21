namespace Currencies.Common.DTO.Currency
{
    public class CurrencyDTO
    {
        public string Id { get; set; } 
        public string NumCode { get; set; } 
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; } 
        public decimal Value { get; set; }
        public decimal VunitRate { get; set; }
    }
}
