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
    /// Logika interakcji dla klasy BorderedTextBlock.xaml
    /// </summary>
    public partial class BorderedTextBlock : UserControl
    {
        public string Value 
        { 
            get => TextBlockContent.Text;
            set => TextBlockContent.Text = value;
        }

        public FontWeight FontWeights
        {
            get => TextBlockContent.FontWeight;
            set => TextBlockContent.FontWeight = value;
        }

        public Brush BackgroundColor
        {
            get => Background;
            set => Background = value;
        }
        
        public Brush FontColor
        {
            get => TextBlockContent.Foreground;
            set => TextBlockContent.Foreground = value;
        }
        
        public Brush BorderColor
        {
            get => BorderBrush;
            set => BorderBrush = value;
        }

        public BorderedTextBlock()
        {
            InitializeComponent();
        }
    }
}
