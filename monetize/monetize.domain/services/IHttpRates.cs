using System.Threading.Tasks;
using monetize.domain.models;

namespace monetize.domain.services
{
    public interface IHttpRates
    {
        Task<RatesResponse> GetRatesAsync(string from, string to);
    }
}