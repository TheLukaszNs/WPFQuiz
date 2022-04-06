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
            var question = new Question();
            question.Content = TextBox_QuestionTitle.Text;

            foreach (var quizAnswer in _answerComponents)
            {
                question.Answers.Add(quizAnswer.ToAnswer());
            }

            _quiz.Questions.Add(question);

            var coder = new CommonLibrary.Base64Coder();
            var data = coder.Encode(JsonSerializer.Serialize(_quiz));

            MessageBox.Show(coder.Decode(data));
        }
    }
}
