using Currencies.Common.DTO;

namespace Currencies.BLL.IServices
{
    public interface ICurrencyService 
    {
        Task<CurrencyDTO> GetCurrencyByIdAsync(string currencyId);
        Task<ICollection<CurrencyDTO>> GetCurrenciesAsync();
    }
}
