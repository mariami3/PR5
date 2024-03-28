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

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
        public user()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user1 ad0Window = new user1();
            ad0Window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            user2 ad0Window = new user2();
            ad0Window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            user3 ad0Window = new user3();
            ad0Window.ShowDialog();
        }
    }
}
