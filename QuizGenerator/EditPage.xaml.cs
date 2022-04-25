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
    /// Logika interakcji dla klasy EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private List<QuizAnswer> _answerComponents = new List<QuizAnswer>();
        private Quiz _quiz;
        private int _questionIndex = 0;

        public EditPage(Quiz quiz)
        {
            InitializeComponent();

            _quiz = quiz;
            _answerComponents.AddRange(new List<QuizAnswer>() { QuizAnswer_A, QuizAnswer_B, QuizAnswer_C, QuizAnswer_D });

            ShowQuiz();
        }

        private void ShowQuiz()
        {
            TextBlock_AllCount.Text = _quiz.Questions.Count.ToString();
            TextBox_Title.Text = _quiz.Title;
            
            double seconds = _quiz.Duration % 60;
            double minutes = (_quiz.Duration - seconds) / 60;

            TextBox_TimeMinutes.Text = minutes.ToString().Length == 1 ? $"0{minutes}" : minutes.ToString();
            TextBox_TimeSeconds.Text = seconds.ToString().Length == 1 ? $"0{seconds}" : seconds.ToString();

            ShowQuestion(0);
        } 

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= _quiz.Questions.Count) return;
            _questionIndex = index;

            Question q = _quiz.Questions[index];
            TextBlock_Current.Text = (_questionIndex + 1).ToString();
            TextBox_QuestionTitle.Text = q.Content;

            for (int i = 0; i < _answerComponents.Count; i++)
            {
                _answerComponents[i].AnswerContent = q.Answers[i].Content;
                _answerComponents[i].IsCorrect = q.Answers[i].IsCorrect;
            }
        }

        private bool ModifyQuestion(int index)
        {
            if (index < 0 || index >= _quiz.Questions.Count) return false;

            Question q = _quiz.Questions[index];

            if (!TextBox_QuestionTitle.Validate()) return false;
            
            for (int i = 0; i < _answerComponents.Count; i++)
            {
                if (!_answerComponents[i].Validate()) return false;

                q.Answers[i] = _answerComponents[i].ToAnswer();
            }
            
            q.Content = TextBox_QuestionTitle.Text;

            _quiz.Questions[index] = q;

            return true;
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (_questionIndex + 1 >= _quiz.Questions.Count) return;

            if (!ModifyQuestion(_questionIndex)) return;

            ShowQuestion(_questionIndex + 1);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            if (_questionIndex - 1 < 0) return;

            if (!ModifyQuestion(_questionIndex)) return;

            ShowQuestion(_questionIndex - 1);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!(TextBox_TimeMinutes.Validate() & TextBox_TimeSeconds.Validate() & TextBox_Title.Validate()))
                return;

            ModifyQuestion(_questionIndex);

            string path = GetSavePath();
            if (path == null)
                return;

            _quiz.Title = TextBox_Title.Text;
            _quiz.Duration = 60 * int.Parse(TextBox_TimeMinutes.Text) + int.Parse(TextBox_TimeSeconds.Text);

            if (QuizData.SaveEncode(new JSONSerializer<Quiz>(), new Base64Coder(), _quiz, path))
            {
                MessageBox.Show("Plik został zapisany!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
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
    }
}
