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

        public OverviewPage(Quiz quiz, int score, uint correctedCount)
        {
            this.quiz = quiz;
            this.score = score;
            this.correctedCount = correctedCount;

            InitializeComponent();

            Result.Text = $"Wynik: {score}/{correctedCount}";
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
