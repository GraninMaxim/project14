using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using LibMatrix;

namespace project14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        Matrix<int> matrix;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Password pas = new();
            pas.Owner = this;
            pas.ShowDialog();
        }

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы уверены, что хотите выйти?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @".\matrix" + matrix.Extension;
                matrix.Save(path);
                MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @".\matrix" + matrix.Extension;
                matrix.Open(path);
                dataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N. Найти номер последнего из ее " +
                "столбцов, содержащих равное количество положительных и отрицательныхэлементов (нулевые " +
                "элементы матрицы не учитываются). Если таких столбцов нет, то вывести 0.", "О программе",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            result.Text = null;
        }

        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result.Text = null;

                StreamReader streamReader = new("config.ini");
                using (streamReader)
                {
                    int rowCount = Convert.ToInt32(streamReader.ReadLine());
                    int columnCount = Convert.ToInt32(streamReader.ReadLine());
                    int res = matrix.Calculate(rowCount, columnCount);
                    result.Text += res.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.ShowDialog();
            settings.Owner = this;
        }

        private void CreateFill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader streamReader = new("config.ini");
                using (streamReader)
                {
                    int rowCount = Convert.ToInt32(streamReader.ReadLine());
                    int columnCount = Convert.ToInt32(streamReader.ReadLine());
                    int minValue = Convert.ToInt32(streamReader.ReadLine());
                    int maxValue = Convert.ToInt32(streamReader.ReadLine());

                    matrix = new Matrix<int>(rowCount, columnCount);
                    matrix.Fill(rowCount, columnCount, minValue, maxValue);
                    dataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
