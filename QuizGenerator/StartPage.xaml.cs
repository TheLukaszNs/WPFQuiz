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
using Microsoft.Win32;

namespace QuizGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GeneratorPage());
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                FileName = "Quiz.quiz",
                DefaultExt = ".quiz",
                Filter = "Quiz data|*.quiz"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == false) return;

            Quiz quiz = QuizData.LoadDecode(new JSONSerializer<Quiz>(), new Base64Coder(), openFileDialog.FileName);

            NavigationService.Navigate(new EditPage(quiz));
        }

        private void Button_End_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
