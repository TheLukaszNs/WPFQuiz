using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolver
{
    internal class Question
    {
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Answer> SelectedAnswers { get; set; }

        public Question(string content, List<Answer> answers)
        {
            Content = content;
            Answers = answers;
            SelectedAnswers = new List<Answer>();
        }
    }
}
