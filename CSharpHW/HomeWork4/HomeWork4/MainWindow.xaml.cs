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

namespace HomeWork4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MinYear = 1900;
        private const int PhoneLength = 12;
        private const int AdditionalMaxLength = 2000;

        private bool IsGenderChecked { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((FirstNameBox.Text.Where(Char.IsLetter).ToArray().Length < FirstNameBox.Text.Length) ||
                (FirstNameBox.Text.Length >= 255) ||
                (LastNameBox.Text.Where(Char.IsLetter).ToArray().Length < LastNameBox.Text.Length) ||
                (LastNameBox.Text.Length >= 255) || (BirthdayBox.SelectedDate == null) ||
                (BirthdayBox.SelectedDate.Value.Year > DateTime.Now.Year) || (BirthdayBox.SelectedDate.Value.Year < MinYear) ||
                (!IsGenderChecked) ||
                (!EmailBox.Text.Contains("@")) || (EmailBox.Text.Length >= 255) ||
                (PhoneBox.Text.Where(Char.IsDigit).ToArray().Length < FirstNameBox.Text.Length) ||
                (PhoneBox.Text.Length != PhoneLength) ||
                (AdditionalBox.Text.Length >= AdditionalMaxLength))
                MessageBox.Show("Validation error", "Error");
            else
                MessageBox.Show("Successful");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            IsGenderChecked = true;
        }
    }
}
