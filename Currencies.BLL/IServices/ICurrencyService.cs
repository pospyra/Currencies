using Currencies.Common.DTO.Currency;

namespace Currencies.BLL.IServices
{
    public interface ICurrencyService
    {
        Task<CurrencyDTO> GetCurrencyByIdAsync(string currencyId);

        Task<ICollection<CurrencyDTO>> GetCurrenciesAsync(int pageNumber, int pageSize);
    }
}
