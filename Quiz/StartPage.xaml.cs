using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Win32;
using CommonLibrary;

namespace QuizSolver
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage() => InitializeComponent();

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Quizdata";
            openFileDialog.DefaultExt = ".quiz";
            openFileDialog.Filter = "Quiz files (*.quiz)|*.quiz";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            { 
                string filename = openFileDialog.FileName;

                NavigationService.Navigate(new QuizPage(QuizData.LoadDecode(new JSONSerializer<Quiz>(), new Base64Coder(), filename)));
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
