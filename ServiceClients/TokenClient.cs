using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClients.Interfaces;

namespace ServiceClients
{
    public class TokenClient : ITokenClient
    {
        readonly HttpClient _httpClient;
        public TokenClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string GetToken()
        {
            return "sample token";
        }
    }
}
