using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public static class QuizData
    {
        public static void SaveEncode(ISerializer<string, Quiz> serializer, ICoder<string> coder, Quiz data)
        {
            var serialized = serializer.Serialize(data);
            var coded = coder.Encode(serialized);
        }
    }
}
