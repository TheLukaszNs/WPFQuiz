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

namespace QuizGenerator
{
    public enum TextBoxType
    {
        Integer,
        Double,
        Text
    }

    public class EnforceTypeTextBox : TextBox
    {
        public TextBoxType Type { get; set; }

        public Brush ErrorBrush {
            get => (Brush)GetValue(ErrorBrushProperty);
            set => SetValue(ErrorBrushProperty, value);
        }
        public Brush DefaultBrush
        {
            get => (Brush)GetValue(DefaultBrushProperty);
            set => SetValue(DefaultBrushProperty, value);
        }
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        static EnforceTypeTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnforceTypeTextBox), new FrameworkPropertyMetadata(typeof(EnforceTypeTextBox)));
            TextProperty.OverrideMetadata(typeof(EnforceTypeTextBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(ValuePropertyChanged)));
        }
        

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetValue(BorderBrushProperty, DefaultBrush);
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EnforceTypeTextBox instance = (EnforceTypeTextBox)d;

            if(CheckType(instance, e.NewValue.ToString()))
            {
                instance.Text = e.NewValue.ToString();
                instance.SetValue(ErrorProperty, string.Empty);
                instance.SetValue(BorderBrushProperty, instance.GetValue(DefaultBrushProperty));
            }
            else
            {
                instance.Text = e.OldValue.ToString();
                instance.SetValue(ErrorProperty, "Wprowadzono nieprawidłowy typ.");
                instance.SetValue(BorderBrushProperty, instance.GetValue(ErrorBrushProperty));
            }

        }

        private static bool CheckType(EnforceTypeTextBox textBox, string value)
        {
            if (value == string.Empty) return true;

            switch(textBox.Type)
            {
                case TextBoxType.Integer:
                    return int.TryParse(value, out _);
                case TextBoxType.Double:
                    return double.TryParse(value, out _);
                case TextBoxType.Text:
                default:
                    return true;
            }
        }

        public static readonly DependencyProperty ErrorBrushProperty =
            DependencyProperty.Register(nameof(ErrorBrush), typeof(Brush), typeof(EnforceTypeTextBox), new PropertyMetadata(Brushes.Red));

        public static readonly DependencyProperty DefaultBrushProperty =
            DependencyProperty.Register(nameof(DefaultBrush), typeof(Brush), typeof(EnforceTypeTextBox), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(nameof(Error), typeof(string), typeof(EnforceTypeTextBox), new PropertyMetadata(string.Empty));


    }
}
