using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Quiz
    {
        public string Title { get; set; }

        private List<Question> questions = new List<Question>();
        public List<Question> Questions { get => questions; set => questions = value; }
    }
}
