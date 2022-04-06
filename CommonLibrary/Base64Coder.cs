using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Base64Coder : ICoder<string>
    {
        public string Decode(string data)
        {
            byte[] t = Convert.FromBase64String(data);
            return System.Text.Encoding.UTF8.GetString(t);
        }

        public string Encode(string data)
        {
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(dataBytes);
        }
    }
}
