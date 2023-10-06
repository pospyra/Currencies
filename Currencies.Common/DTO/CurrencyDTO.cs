namespace Currencies.Common.DTO
{
    public class CurrencyDTO
    {
        public string Id { get; set; } = string.Empty;
        public string NumCode { get; set; } = string.Empty;
        public string CharCode { get; set; } = string.Empty;
        public int Nominal { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal VunitRate { get; set; }
    }
}
