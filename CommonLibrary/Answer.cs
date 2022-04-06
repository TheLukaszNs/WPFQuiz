using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Answer
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string text, bool isCorrect)
        {
            Content = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
