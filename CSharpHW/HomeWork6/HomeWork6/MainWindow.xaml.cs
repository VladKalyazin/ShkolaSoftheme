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

namespace HomeWork6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaxValue = 10;
        private Random Randomizer = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt32(NumberEdit.Text);
            }
            catch
            {
                MessageBox.Show("Validatin error", "Error");
                return;
            }

            int randValue = Randomizer.Next(MaxValue) + 1;
            if (randValue == value)
                ResultBox.Text = "Congratulations! You was right!";
            else
                ResultBox.Text = $"The number was {randValue}. Maybe you'll right next time.";

        }
    }
}
