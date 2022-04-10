using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Question
    {
        public string Content { get; set; }

        private List<Answer> answers = new List<Answer>();
        public List<Answer> Answers { get => answers; set => answers = value; }

        public override string ToString() => Content;
    }
}
