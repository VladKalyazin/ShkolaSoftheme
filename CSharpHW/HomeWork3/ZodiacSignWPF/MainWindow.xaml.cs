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


namespace ZodiacSignWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<Zodiac.ZodiacSign, CroppedBitmap> ZodiacImages { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = (sender as DatePicker)?.SelectedDate;
            if (selectedDate != null)
            {
                AgeDisplay.Text = Zodiac.GetAge(selectedDate ?? default(DateTime)).ToString();
                Zodiac.ZodiacSign sign = Zodiac.GetZodiacSign(selectedDate ?? default(DateTime));
                ZodiacTextDisplay.Text = sign.ToString("g");
                ZodiacImageDisplay.Source = ZodiacImages[sign];
            }
        }

        private void CutImage()
        {
            ZodiacImages = new Dictionary<Zodiac.ZodiacSign, CroppedBitmap>();
            Zodiac.ZodiacSign sign = Zodiac.ZodiacSign.Capricorn;

            BitmapImage src = TryFindResource("ZodiacsImage") as BitmapImage;
            int partWidth = src.PixelWidth / 4;
            int partHeight = src.PixelHeight / 3;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    ZodiacImages.Add(sign++, new CroppedBitmap(src, new Int32Rect(j * partWidth, i * partHeight, partWidth, partHeight)));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CutImage();
        }
    }
}
