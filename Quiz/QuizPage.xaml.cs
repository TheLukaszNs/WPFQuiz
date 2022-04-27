using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using CommonLibrary;

namespace QuizSolver
{
    /// <summary>
    /// Logika interakcji dla klasy QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        private DispatcherTimer timer;
        private TimeSpan time;
        private Quiz quiz;
        private int _Score { get; set; }
        private int _CurrentQuestion { get; set; }
        private uint correctedCount;
        private List<Answer> selectedAnswers;

        public QuizPage(Quiz quiz)
        {
            this.quiz = quiz;

            InitializeComponent();

            Title.Text = this.quiz.Title;
            _Score = 0;
            _CurrentQuestion = 0;
            correctedCount = 0;
            selectedAnswers = new List<Answer>();

            TimerStart();
            DisplayQuestion();
        }

        private void TimerStart()
        {
            time = TimeSpan.FromSeconds(quiz.Duration);
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Timer.Text = time.ToString("mm\\:ss");

            if (time == TimeSpan.Zero)
            { 
                timer.Stop();
                ChangeScreen();
            }

            else
                time = time.Subtract(TimeSpan.FromSeconds(1));
        }

        private void DisplayQuestion()
        {
            Answers.Items.Clear();

            CurrentQuestion.Text = $"{_CurrentQuestion + 1}/{quiz.Questions.Count}";
            Content.Text = quiz.Questions[_CurrentQuestion].Content + "?";

            foreach (Answer a in quiz.Questions[_CurrentQuestion].Answers)
            { 
                Answers.Items.Add(a);

                if (a.IsCorrect)
                    correctedCount++;
            }
        }

        private void UpdateScore()
        {
            foreach (Answer a in Answers.SelectedItems)
            {
                selectedAnswers.Add(a);

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

            else
                ChangeScreen();
        }

        private void ChangeScreen() => NavigationService.Navigate(new OverviewPage(quiz, _Score, correctedCount, selectedAnswers));
    }
}
