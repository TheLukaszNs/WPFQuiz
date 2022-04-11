using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommonLibrary;

namespace QuizSolver
{
    /// <summary>
    /// Logika interakcji dla klasy OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage : Page
    {
        private Quiz quiz;
        private int score;
        private uint correctedCount;
        private List<Answer> selectedAnswers;

        public OverviewPage(Quiz quiz, int score, uint correctedCount, List<Answer> selectedAnswers)
        {
            this.quiz = quiz;
            this.score = score;
            this.correctedCount = correctedCount;
            this.selectedAnswers = selectedAnswers;

            InitializeComponent();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            Result.Text = $"Wynik: {score}/{correctedCount}";

            foreach (Question q in quiz.Questions)
            {
                Summary.Items.Add(new BorderedTextBlock
                {
                    Value = $"Pytanie {Summary.Items.Count + 1}: {q.Content}",
                    FontWeight = FontWeights.Bold,
                    Margin = Summary.Items.Count > 0 ? new Thickness(0, 100, 0, 0) : new Thickness(0, 0, 0, 0)
                });

                foreach (Answer a in q.Answers)
                    Summary.Items.Add(new BorderedTextBlock
                    {
                        Value = a.Content,
                        BorderColor = a.IsCorrect ? Brushes.Green : Brushes.Red,
                        BackgroundColor = selectedAnswers.Contains(a) ?
                            a.IsCorrect ?
                            (Brush)new BrushConverter().ConvertFrom("#2ECC71") :
                            (Brush)new BrushConverter().ConvertFrom("#E74C3C") :
                            Brushes.Transparent,
                        FontColor = selectedAnswers.Contains(a) ? Brushes.White : Brushes.Black
                    });
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
