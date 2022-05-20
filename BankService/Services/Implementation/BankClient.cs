using BankService.Commons;
using BankService.Data.DTOS;
using BankService.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BankService.Services.Implementation
{
    public class BankClient : IBankService
    {
        private readonly string subcriberKey;
        private readonly string RequestUrl;
        public BankClient(IConfiguration configuration)
        {
            subcriberKey = configuration.GetSection("HttpDATA:SubscriberKey").Value;
            RequestUrl = configuration.GetSection("HttpDATA:RequestUrl").Value;

        }

        public async Task<BankToReturnDto> GetBanks()
        {
            var response = await Utilities.Get(RequestUrl, subcriberKey);
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BankToReturnDto>(responseAsString);
            return result;
        }
    }
}
