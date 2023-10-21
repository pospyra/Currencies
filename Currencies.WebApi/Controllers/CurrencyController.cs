using Currencies.BLL.IServices;
using Currencies.Common.DTO.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.WebApi.Controllers
{
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("currencies")]
        public async Task<ActionResult<ICollection<CurrencyDTO>>> GetCurrencies()
        {
            var result = await _currencyService.GetCurrenciesAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("currency")]
        public async Task<ActionResult<CurrencyDTO>> GetCurrencies(string id)
        {
            var result = await _currencyService.GetCurrencyByIdAsync(id);
            return Ok(result);
        }
    }
}