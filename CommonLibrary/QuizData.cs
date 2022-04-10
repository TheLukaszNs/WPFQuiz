﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CommonLibrary
{
    public static class QuizData
    {
        public static bool SaveEncode(ISerializer<Quiz> serializer, ICoder<string> coder, Quiz data, string path)
        {
            string serialized = serializer.Serialize(data);
            string encoded = coder.Encode(serialized);

            try
            {
                using (StreamWriter outputFile = new StreamWriter(path))
                    outputFile.Write(encoded);
            } 
            catch
            {
                return false;
            }

            return true;
        }
    }
}
