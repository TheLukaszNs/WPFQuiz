using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CommonLibrary
{
    public class JSONSerializer<T> : ISerializer<T>
    {
        public string Serialize(T data)
        {
            return JsonSerializer.Serialize(data);
        }

        public T Deserialize(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
