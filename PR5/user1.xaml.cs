using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using System.Xml.Linq;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для user1.xaml
    /// </summary>
    public partial class user1 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public user1()
        {
            InitializeComponent();
            us1.ItemsSource = context.Sessions.ToList();
            film.ItemsSource = context.Movies.ToList();
            film.DisplayMemberPath = "MovieName";
            hall.ItemsSource = context.Halls.ToList();
            hall.DisplayMemberPath = "HallName";
        }
        private bool ValidateFields()
        {
            // Проверяем, что все обязательные поля заполнены
            if (string.IsNullOrWhiteSpace(date.Text) ||
                string.IsNullOrWhiteSpace(time.Text) ||
                film.SelectedItem == null ||
                hall.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return false;
            }

            if (!DateTime.TryParseExact(date.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты и времени. Используйте формат yyyy-MM-dd");
                return false;
            }

            if (!DateTime.TryParseExact(time.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты и времени. Используйте форму HH:mm:ss");
                return false;
            }
            return true;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Sessions c = new Sessions();

            c.DateSession = date.Text;
            c.TimeSession = time.Text;
            c.MovieID = (film.SelectedItem as Movies).ID_Movie;
            c.HallID = (hall.SelectedItem as Halls).ID_Hall;

            context.Sessions.Add(c);

            context.SaveChanges();
            us1.ItemsSource = context.Sessions.ToList();
        }

       

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (us1.SelectedItems != null)
            {
                var selected = us1.SelectedItem as Sessions;


                selected.DateSession = date.Text;
                selected.TimeSession = time.Text;
                selected.MovieID = (film.SelectedItem as Movies).ID_Movie;
                selected.HallID = (hall.SelectedItem as Halls).ID_Hall;

                context.SaveChanges();
                us1.ItemsSource = context.Sessions.ToList();
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (us1.SelectedItems != null)
            {

                Sessions selectSession = (Sessions)us1.SelectedItem;

                context.Sessions.Remove(selectSession);

                context.SaveChanges();
                us1.ItemsSource = context.Sessions.ToList();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void us1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (us1.SelectedItems != null)
            {
                var selected = us1.SelectedItem as Sessions;

                if (selected != null)
                {
                    date.Text = selected.DateSession;
                    time.Text = selected.TimeSession;
                    film.Text = selected.MovieID.ToString();
                    hall.Text = selected.HallID.ToString();

                }
            }
        }
    }
}
