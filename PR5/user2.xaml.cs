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
    /// Логика взаимодействия для user2.xaml
    /// </summary>
    public partial class user2 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();

        public user2()
        {
            InitializeComponent();
            us2.ItemsSource = context.Snacks.ToList();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(price.Text) ||
                string.IsNullOrWhiteSpace(category.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return false;
            }
            if (category.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Котегория должна состоять только из букв.");
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
            if (int.TryParse(price.Text, out int parsedPrice) && parsedPrice > 0)
            {
                Snacks c = new Snacks();

                     c.SnackName = name.Text;
                     c.SnackPrice = price.Text;
                     c.Category = category.Text;

                    context.Snacks.Add(c);

                    context.SaveChanges();
                     us2.ItemsSource = context.Snacks.ToList();
            }
            else
            {
                MessageBox.Show("Цена должна быть положительным числом.");
            }

        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (us2.SelectedItem != null)
            {
                var selected = us2.SelectedItem as Snacks;
                if (int.TryParse(price.Text, out int parsedPrice) && parsedPrice > 0)
                {
                    selected.SnackName = name.Text;
                    selected.SnackPrice = price.Text;
                    selected.Category = category.Text;

                    context.SaveChanges();
                    us2.ItemsSource = context.Snacks.ToList();

                }
                else
                {
                    MessageBox.Show("Цена должна быть положительным числом.");
                }
            }
                    
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (us2.SelectedItem != null)
            {
                context.Snacks.Remove(us2.SelectedItem as Snacks);

                context.SaveChanges();
                us2.ItemsSource = context.Snacks.ToList();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void us2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (us2.SelectedItems != null)
            {
                var selected = us2.SelectedItem as Snacks;

                if (selected != null)
                {
                    name.Text = selected.SnackName;
                    price.Text = selected.SnackPrice;
                    category.Text = selected.Category;
                   
                }
            }
        }
    }
}
