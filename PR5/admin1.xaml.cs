using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для admin1.xaml
    /// </summary>
    public partial class admin1 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();

        public admin1()
        {
            InitializeComponent();
            ad1.ItemsSource = context.Workers.ToList();
            roleid.ItemsSource = context.Roles.ToList();
            roleid.DisplayMemberPath = "RoleName";
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(familia.Text) ||
                string.IsNullOrWhiteSpace(position.Text) ||
                string.IsNullOrWhiteSpace(login.Text) ||
                roleid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }
            if (name.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Имя должно состоять только из букв.");
                return false;
            }

            if (familia.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Фамилия должна состоять только из букв.");
                return false;
            }
            return true;
        }

        private string GetHashedPassword(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        } 
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            Workers c = new Workers();

            c.FirstName = name.Text;
            c.LastName = familia.Text;
            c.Position = position.Text;
            c.Login = login.Text;
            c.Password = GetHashedPassword(password.Password);
            c.RoleID = (roleid.SelectedItem as Roles).ID_Role;

            context.Workers.Add(c);

            context.SaveChanges();
            ad1.ItemsSource = context.Workers.ToList();

        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad1.SelectedItems != null)
            {
                var selected = ad1.SelectedItem as Workers;

             
                selected.FirstName = name.Text;
                selected.LastName = familia.Text;
                selected.Position = position.Text;
                selected.Login = login.Text;
                selected.Password = password.Password;
                selected.RoleID = (roleid.SelectedItem as Roles).ID_Role;

                context.SaveChanges();
                ad1.ItemsSource = context.Workers.ToList();
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ad1.SelectedItems != null)
            {

                Workers selectWorker = (Workers)ad1.SelectedItem;

                context.Workers.Remove(selectWorker);

                context.SaveChanges();
                ad1.ItemsSource = context.Workers.ToList();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin2 ad0Window = new admin2();
            ad0Window.ShowDialog();
        }

        private void ad1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ad1.SelectedItems != null)
            {
                var selected = ad1.SelectedItem as Workers;

                if (selected != null)
                {
                    name.Text = selected.FirstName;
                    familia.Text = selected.LastName;
                    position.Text = selected.Position;
                    roleid.Text = selected.RoleID.ToString();
                    login.Text = selected.Login;
                    password.Password = selected.Password;
                }
            }
        }
    }
}
