using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Question
    {
        public string Text { get; set; }

        private List<Answer> answers = new List<Answer>();
        public List<Answer> Answers { get => answers; set => answers = value; }


    }
}
