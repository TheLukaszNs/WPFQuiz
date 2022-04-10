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

namespace QuizGenerator
{
    public partial class QuizAnswer : UserControl
    {
        public string AnswerContent 
        { 
            get => TextBox_Content.Text; 
            set => TextBox_Content.Text = value; 
        }

        public string Letter 
        {
            get => TextBlock_Letter.Text; 
            set => TextBlock_Letter.Text = value; 
        }

        public bool? IsCorrect
        {
            get => CheckBox_IsCorrect.IsChecked;
            set => CheckBox_IsCorrect.IsChecked = value;
        }


        public QuizAnswer()
        {
            InitializeComponent();
        }

        public Answer ToAnswer() => new Answer { Content = AnswerContent, IsCorrect = IsCorrect ?? false};

        public void Reset()
        {
            AnswerContent = "";
            IsCorrect = false;
        }
    }
}
