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
using System.Windows.Shapes;

namespace project14
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Window_Activate(object sender, EventArgs e)
        {
            inpPassword.Focus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (inpPassword.Password == "123")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Пароль неверен. Повторите ввод.");
                inpPassword.Clear();
                inpPassword.Focus();
            }
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(inpPassword.Password != "123")
            {
                e.Cancel = true;
            }
        }
    }
}
