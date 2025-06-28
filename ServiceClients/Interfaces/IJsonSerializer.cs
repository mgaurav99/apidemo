using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClients.Interfaces
{
    public interface IJsonSerializer
    {
       public T Deserialize<T>(string json);
       public string Serialize<T>(T data);
        
    }
}
