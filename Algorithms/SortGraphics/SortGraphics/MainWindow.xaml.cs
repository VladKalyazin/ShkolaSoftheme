using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
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
using OxyPlot;

namespace SortGraphics
{
    public partial class MainWindow : Window
    {
        public delegate void ProgressBarDelegate();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SortingsTester.ArrayLengthChanged += SortingsTester_ArrayLengthChanged;
            MinArrayLengthTextBox.Text = SortingsTester.MinArrayLength.ToString();
            MaxArrayLengthTextBox.Text = SortingsTester.MaxArrayLength.ToString();
        }

        private void SortingsTester_ArrayLengthChanged(int length)
        {
            Progress.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ProgressBarDelegate( () => Progress.Value = length));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SortingsTester.MinArrayLength = Convert.ToInt32(MinArrayLengthTextBox.Text);
                SortingsTester.MaxArrayLength = Convert.ToInt32(MaxArrayLengthTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Input data is invalid.", "Error");
            }

            var sortings = new Dictionary<string, Action<List<int>>>();

            //sortings.Add("Merge sort (bottom-up)", MergeSort.BottomUp);
            sortings.Add("Merge sort (top-down)", MergeSort.TopDown);
            sortings.Add("Binary tree sort", SortingBinaryTree.Sort);
            sortings.Add("Quick sort", QuickSort.LomutoSort);
            sortings.Add("Hybrid quick sort", QuickSort.WithInsertionSort);

            await Task.Factory.StartNew(() => 
            {
                Progress.Dispatcher.Invoke(DispatcherPriority.Normal, new ProgressBarDelegate(() =>
                {
                    Progress.Visibility = Visibility.Visible;
                    Progress.Minimum = SortingsTester.MinArrayLength;
                    Progress.Maximum = SortingsTester.MaxArrayLength;
                }));

                var model = new GraphicViewModel(sortings);
                Dispatcher.Invoke( () => DataContext = model);

                Progress.Dispatcher.Invoke(DispatcherPriority.Normal, new ProgressBarDelegate(() => Progress.Visibility = Visibility.Hidden));

            });
        }

    }
}
