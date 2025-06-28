using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ServiceClients.Interfaces;
using ServiceClients.Models.Meteo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceClients
{
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions _options;
        public SystemTextJsonSerializer(JsonSerializerOptions options = null)
        {
            _options = options ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json,_options);
        }

        public string Serialize<T>(T data)
        {
            return JsonSerializer.Serialize<T>(data,_options);
        }
    }
}
