using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для admin2.xaml
    /// </summary>
    public partial class admin2 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public admin2()
        {
            InitializeComponent();
            ad2.ItemsSource = context.Movies.ToList();
            
        }


        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(genre.Text) ||
                string.IsNullOrWhiteSpace(director.Text) ||
                string.IsNullOrWhiteSpace(casts.Text) ||
                string.IsNullOrWhiteSpace(time.Text) ||
                string.IsNullOrWhiteSpace(rating.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return false;
            }

            if (!IsValidTimeFormat(time.Text))
            {
                MessageBox.Show("Неверный формат времени. Используйте формат hh:mm.");
                return false;
            }

            if (!IsValidRating(rating.Text))
            {
                MessageBox.Show("Рейтинг должен быть числом от 1 до 10.");
                return false;
            }
            if (genre.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Жанр должен состоять только из букв.");
                return false;
            }

            if (director.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Имя режиссер должен состоять только из букв.");
                return false;
            }
            if (casts.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Список актеров должен состоять только из букв.");
                return false;
            }

            return true;
        }

        private bool IsValidRating(string input)
        {
            if (int.TryParse(input, out int ratingValue))
            {
                return ratingValue >= 1 && ratingValue <= 10; // Проверяем, что рейтинг в диапазоне от 1 до 10
            }

            return false;
        }

        private bool IsValidTimeFormat(string time)
        {
            TimeSpan tempTime;
            return TimeSpan.TryParseExact(time, "h\\:mm", CultureInfo.InvariantCulture, out tempTime);
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Movies c = new Movies();

            c.MovieName = name.Text;
            c.Genre = genre.Text;
            c.Director = director.Text;
            c.Casts = casts.Text;
            c.TimeMovie = time.Text;
            c.Rating = rating.Text;
            

            context.Movies.Add(c);

            context.SaveChanges();
            ad2.ItemsSource = context.Movies.ToList();
        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad2.SelectedItems != null)
            {
                var selected = ad2.SelectedItem as Movies;


                selected.MovieName = name.Text;
                selected.Genre = genre.Text;
                selected.Director = director.Text;
                selected.Casts = casts.Text;
                selected.TimeMovie = time.Text;
                selected.Rating = rating.Text;

                context.SaveChanges();
                ad2.ItemsSource = context.Movies.ToList();
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad2.SelectedItems != null)
            {

                Movies selectMovies = (Movies)ad2.SelectedItem;

                context.Movies.Remove(selectMovies);

                context.SaveChanges();
                ad2.ItemsSource = context.Movies.ToList();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin3 ad0Window = new admin3();
            ad0Window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ad2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ad2.SelectedItems != null)
            {
                var selected = ad2.SelectedItem as Movies;

                if (selected != null)
                {
                    name.Text = selected.MovieName;
                    genre.Text = selected.Genre;
                    director.Text = selected.Director;
                    casts.Text = selected.Casts;
                    time.Text = selected.TimeMovie;
                    rating.Text = selected.Rating;
                }
            }
        }
    }
}
