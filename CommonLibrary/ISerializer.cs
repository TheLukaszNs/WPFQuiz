using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ISerializer<T, V>
    {
        T Serialize(V data);
        V Deserialize(T data);
    }
}
