using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using monetize.domain.models;
using monetize.domain.services;
using Newtonsoft.Json;

namespace monetize.application.services
{
    public class HttpRates : IHttpRates
    {
        private IConfiguration _config;
        private string BaseURl;
        private string AccessKey;
        private HttpClient Api = new HttpClient();
        public HttpRates(IConfiguration iconfig)
        {
            _config = iconfig;
            BaseURl = _config.GetSection("BaseURL").Value;
            AccessKey = _config.GetSection("AccessKey").Value;
        }
        async public Task<RatesResponse> GetRatesAsync(){
            var response  = await Api.GetAsync($"{BaseURl}?access_key={AccessKey}&symbols=USD,BRL,EUR");
            return JsonConvert.DeserializeObject<RatesResponse>(await response.Content.ReadAsStringAsync());
        }
  }
}