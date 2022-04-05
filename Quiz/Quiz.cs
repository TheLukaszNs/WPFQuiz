using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolver
{
    internal class Quiz
    {
        public string Title { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string title)
        {
            Title = title;
            Questions = new List<Question>();
            Questions.Add(new Question("What is the capital of France?", 
                new List<Answer>() { 
                    new Answer("A. Paris", true), 
                    new Answer("B. London", false), 
                    new Answer("C. Berlin", false), 
                    new Answer("D. Madrid", false) 
                }));
        }
    }
}
