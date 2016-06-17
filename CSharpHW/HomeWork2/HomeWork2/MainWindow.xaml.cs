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
using System.Reflection;

namespace HomeWork2
{
    public class ListOfTypes : List<Type>
    {

    }

    public partial class MainWindow : Window
    {
        private ListOfTypes TypesArray { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            TypesArray = TryFindResource("TypesArray") as ListOfTypes;
            if (TypesArray != null)
            {
                TypesArray.Add(new SByte().GetType());
                TypesArray.Add(new Int16().GetType());
                TypesArray.Add(new Int32().GetType());
                TypesArray.Add(new Int64().GetType());
                TypesArray.Add(new Byte().GetType());
                TypesArray.Add(new UInt16().GetType());
                TypesArray.Add(new UInt32().GetType());
                TypesArray.Add(new UInt64().GetType());
                TypesArray.Add(new Decimal().GetType());
                TypesArray.Add(new Single().GetType());
                TypesArray.Add(new Double().GetType());
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox TypesListBox = sender as ComboBox;
            Type t = TypesListBox?.SelectedItem as Type;
            if (t == null)
                return;
            string result = "default = ";
            object instance = Activator.CreateInstance(t);
            result += instance;
            result += "\nmin = ";
            result += t.GetField("MinValue", BindingFlags.Public | BindingFlags.Static).GetValue(instance).ToString();
            result += "\nmax = ";
            result += t.GetField("MaxValue", BindingFlags.Public | BindingFlags.Static).GetValue(instance).ToString();
            ResultBox.Text = result;
        }
    }
}
