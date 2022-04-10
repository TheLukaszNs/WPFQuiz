using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class OneToOneCoder : ICoder<string>
    {
        public string Decode(string data) => data;

        public string Encode(string data) => data;
    }
}
