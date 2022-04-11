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
        public bool Required { get; set; }

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
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        static EnforceTypeTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnforceTypeTextBox), new FrameworkPropertyMetadata(typeof(EnforceTypeTextBox)));
            TextProperty.OverrideMetadata(typeof(EnforceTypeTextBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(ValuePropertyChanged)));
        }
        

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            BorderBrush = DefaultBrush;
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EnforceTypeTextBox instance = (EnforceTypeTextBox)d;

            if(CheckType(instance, e.NewValue.ToString()))
            {
                instance.Text = e.NewValue.ToString();
                instance.Error = string.Empty;
                instance.BorderBrush = instance.DefaultBrush;
            }
            else
            {
                instance.Text = e.OldValue.ToString();
                instance.Error = "Wprowadzono nieprawidłowy typ.";
                instance.BorderBrush = instance.ErrorBrush;
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

        public bool Validate()
        {
            if (!CheckType(this, Text))
            {
                Error = "Wprowadzono nieprawidłowy typ.";
                BorderBrush = ErrorBrush;
                return false;
            }

            if (Required && string.IsNullOrEmpty(Text))
            {
                Error = "To pole jest wymagane.";
                BorderBrush = ErrorBrush;
                return false;
            }

            Error = string.Empty;
            BorderBrush = DefaultBrush;
            return true;
        }

        public static readonly DependencyProperty ErrorBrushProperty =
            DependencyProperty.Register(nameof(ErrorBrush), typeof(Brush), typeof(EnforceTypeTextBox), new PropertyMetadata(Brushes.Red));

        public static readonly DependencyProperty DefaultBrushProperty =
            DependencyProperty.Register(nameof(DefaultBrush), typeof(Brush), typeof(EnforceTypeTextBox), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(nameof(Error), typeof(string), typeof(EnforceTypeTextBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string), typeof(EnforceTypeTextBox), new PropertyMetadata(string.Empty));
    }
}
