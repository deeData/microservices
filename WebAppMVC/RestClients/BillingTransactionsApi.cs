using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.RestClients
{
    public class BillingTransactionsApi : IBillingTransactionsApi
    {
        //Refit implementation
        private IBillingTransactionsApi _restClient;
        public BillingTransactionsApi(IConfiguration config, HttpClient httpClient)
        {
            string apiHostAndPort = config.GetSection("ApiServiceLocations").GetValue<string>("BillingApiLocation");
            httpClient.BaseAddress = new Uri($"https://{apiHostAndPort}");
            //link IBillingTransactions to the endpoints by using Refit object RestService
            //Refit doesn't require need of header type and to serialize or deserialize requests/response
            _restClient = RestService.For<IBillingTransactionsApi>(httpClient);
        }

        public async Task<List<LedgerItemDto>> GetAllTransactions()
        {
            try
            {
                return await _restClient.GetAllTransactions();
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            
        }

    }
}
