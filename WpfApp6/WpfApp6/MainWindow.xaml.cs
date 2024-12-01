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

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void GenerateNumbers_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtStart.Text, out int start) || !int.TryParse(txtEnd.Text, out int end))
            {
                MessageBox.Show("Введите допустимые целочисленные значения.");
                return;
            }

            if (start > end)
            {
                MessageBox.Show("Начальное значение должно быть меньше или равно конечному значению.");
                return;
            }


            lstNumbers.Items.Clear(); // Очищение предыдущего номера

            NumberGenerator generator = new NumberGenerator();
            await Task.Run(() =>
            {
                foreach (int number in generator.GenerateNumbers(start, end))
                {
                    this.Dispatcher.Invoke(() => lstNumbers.Items.Add(number)); // Обновлять пользовательский интерфейс в основном потоке
                }
            });

            MessageBox.Show("Генерация завершена!");
        }
    }
}
