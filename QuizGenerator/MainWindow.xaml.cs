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
using System.Text.Json;
using Microsoft.Win32;
using CommonLibrary;

namespace QuizGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<QuizAnswer> _answerComponents = new List<QuizAnswer>();
        private Quiz _quiz = new Quiz();

        public MainWindow()
        {
            InitializeComponent();

            _answerComponents.AddRange(new List<QuizAnswer>() { QuizAnswer_A, QuizAnswer_B, QuizAnswer_C, QuizAnswer_D });
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBox_QuestionTitle.Validate()) return;

            Question question = new Question();
            question.Content = TextBox_QuestionTitle.Text;

            bool questionsReady = true;
            foreach (var quizAnswer in _answerComponents)
            {
                if (!quizAnswer.Validate())
                {
                    questionsReady = false;
                    continue;
                }
            }

            if (!questionsReady) return;
            _answerComponents.ForEach((QuizAnswer qA) => {
                question.Answers.Add(qA.ToAnswer());
                qA.Reset();
            });


            _quiz.Questions.Add(question);

            TextBlock_Count.Text = _quiz.Questions.Count.ToString();
            TextBox_QuestionTitle.Text = "";
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if(_quiz.Questions.Count == 0)
            {
                MessageBox.Show("Nie dodano pytań do Quizu!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (!(TextBox_TimeMinutes.Validate() & TextBox_TimeSeconds.Validate() & TextBox_Title.Validate()))
                return;

            string path = GetSavePath();
            if (path == null) 
                return;

            _quiz.Title = TextBox_Title.Text;
            _quiz.Duration = 60 * int.Parse(TextBox_TimeMinutes.Text) + int.Parse(TextBox_TimeSeconds.Text);

            if (QuizData.SaveEncode(new JSONSerializer<Quiz>(), new Base64Coder(), _quiz, path))
                MessageBox.Show("Plik został zapisany!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Wystąpił błąd zapisu!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private string GetSavePath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = "Quiz.quiz",
                DefaultExt = ".quiz",
                Filter = "Quiz data|*.quiz"
            };

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
                return saveFileDialog.FileName;

            return null;
        }

        private void EnforceTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
