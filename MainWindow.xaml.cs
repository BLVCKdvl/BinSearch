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

namespace BinSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, SolidColorBrush> dict;

        int searchingElementIndex = BOX_SIZE*BOX_SIZE / 2;

        int searchingElement;

        bool IsSorted = false;

        const int BOX_SIZE = 8;
        public MainWindow()
        {
            InitializeComponent();
            dict = new Dictionary<int, SolidColorBrush>();
            for (int i = 1; i < BOX_SIZE*BOX_SIZE + 1; i++)
            {
                dict.Add(i, Brushes.Aqua);
            }

            for (int i = 0; i < BOX_SIZE; i++)
            {
                box.RowDefinitions.Add(new RowDefinition());
                box.ColumnDefinitions.Add(new ColumnDefinition());
            }

            ShuffleArray();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShuffleArray();
            Random rnd = new Random();
            searchingElement = rnd.Next(1, 64);
            textBox.Text = $"Поиск элемента {searchingElement}";
            IsSorted = false;
            //FillGrid();
            //IsSorted = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!IsSorted)
            {
                Random rnd = new Random();
                searchingElement = rnd.Next(1, 64);
                textBox.Text = $"Поиск элемента {searchingElement}";
                FillGrid();
                MessageBox.Show("Массив отсортирован","Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                IsSorted = true;
                return;
            }

            dict[searchingElementIndex] = Brushes.GreenYellow;
            FillGrid();
            
        }

        private void BlockLeftElements()
        {

        }

        private void BlockRightElements()
        {

        }
        //public 

        public Button GETBTN(int row, int column)
        {
            return box.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column) as Button;
        }

        public void ShuffleArray()
        {
            box.Children.Clear();
            Random rand = new Random();
            for (int i = 0; i < BOX_SIZE; i++)
            {
                for (int j = 0; j < BOX_SIZE; j++)
                {
                    var btn = new Button() { Content = $"{rand.Next(1, 64)}", Margin = new Thickness(5), Background = Brushes.Aqua };
                    box.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }
        }
        private void FillGrid()
        {
            box.Children.Clear();
            int number = 1;
            for (int i = 0; i < BOX_SIZE; i++)
            {
                for (int j = 0; j < BOX_SIZE; j++)
                {
                    var btn = new Button() { Content = $"{number}", Margin = new Thickness(5), Background = dict[number] };
                    box.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    number++;
                }
            }
        }

    }
}
