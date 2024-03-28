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
    /// Логика взаимодействия для admin3.xaml
    /// </summary>
    public partial class admin3 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public admin3()
        {
            InitializeComponent();
            ad3.ItemsSource = context.Halls.ToList();
            size.ItemsSource = context.Halls.ToList();
            size.DisplayMemberPath = "Size";
            screen.ItemsSource = context.Halls.ToList();
            screen.DisplayMemberPath = "ScreenType";
            place.ItemsSource = context.Halls.ToList();
            place.DisplayMemberPath = "FreePlace";
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(size.Text) ||
                string.IsNullOrWhiteSpace(screen.Text) ||
                string.IsNullOrWhiteSpace(place.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }

            if (!int.TryParse(place.Text, out _))
            {
                MessageBox.Show("Количество свободных мест должно быть числом.");
                return false;
            }

            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Halls c = new Halls();

            c.HallName = name.Text;
            c.Size = size.Text;
            c.ScreenType = screen.Text;
            c.FreePlace = int.Parse(place.Text);

            context.Halls.Add(c);

            context.SaveChanges();
            ad3.ItemsSource = context.Halls.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad3.SelectedItems != null)
            {
                var selected = ad3.SelectedItem as Halls;


                selected.HallName = name.Text;
                selected.Size = size.Text;
                selected.ScreenType = screen.Text;
                selected.FreePlace = int.Parse(place.Text);

                context.SaveChanges();
                ad3.ItemsSource = context.Halls.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad3.SelectedItems != null)
            {

                Halls selectHall = (Halls)ad3.SelectedItem;

                context.Halls.Remove(selectHall);

                context.SaveChanges();
                ad3.ItemsSource = context.Halls.ToList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            admin2 ad0Window = new admin2();
            ad0Window.ShowDialog();
        }

        private void ad3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ad3.SelectedItems != null)
            {
                var selected = ad3.SelectedItem as Halls;

                if (selected != null)
                {
                    name.Text = selected.HallName;
                    size.Text = selected.Size;
                    screen.Text = selected.ScreenType;
                    place.Text = selected.FreePlace.ToString();
                   
                }
            }
        }
    }
}
