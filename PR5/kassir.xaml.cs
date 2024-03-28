using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для kassir.xaml
    /// </summary>
    public partial class kassir : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public kassir()
        {
            InitializeComponent();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kassir1 ks1Window = new kassir1();
            ks1Window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            kassir2 ks2Window = new kassir2();
            ks2Window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            kassir3 ks3Window = new kassir3();
            ks3Window.ShowDialog();
        }
    }
}
