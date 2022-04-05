using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizSolver
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Quiz quiz;
        private int _Score { get; set; }
        private int _CurrentQuestion { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            quiz = new Quiz("Test o wszystkim i o niczym");
            Title.Text = quiz.Title;
            _Score = 0;
            _CurrentQuestion = 0;

            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            CurrentQuestion.Text = $"{_CurrentQuestion + 1}/{quiz.Questions.Count}";
            Content.Text = quiz.Questions[_CurrentQuestion].Content;

            foreach (Answer a in quiz.Questions[_CurrentQuestion].Answers)
                Answers.Items.Add(a);
        }

        private void UpdateScore()
        {
            quiz.Questions[_CurrentQuestion].SelectedAnswers.AddRange(Answers.SelectedItems.Cast<Answer>());

            foreach (Answer a in quiz.Questions[_CurrentQuestion].SelectedAnswers)
            {
                if (a.IsCorrect)
                    _Score++;
                else
                    _Score--;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore();

            if (_CurrentQuestion + 1 < quiz.Questions.Count)
            {
                _CurrentQuestion++;

                DisplayQuestion();
            }
        }
    }
}
