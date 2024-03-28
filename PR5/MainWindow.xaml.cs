using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using PR5.CinemaDataSetTableAdapters;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkersTableAdapter adapter = new WorkersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private string ComputeHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text) || string.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }

            var allLogins = adapter.GetData().Rows;

            bool isUserAuthenticated = false;
            int roleId = 0;

            foreach (DataRow loginData in allLogins)
            {
                if (loginData[5].ToString() == login.Text)
                {
                    string storedPassword = loginData[6].ToString();

                    if (storedPassword == password.Password || ComputeHash(password.Password) == storedPassword)
                    {
                        roleId = (int)loginData[4];
                        isUserAuthenticated = true;
                        break;
                    }
                }
            }

            if (isUserAuthenticated)
            {
                switch (roleId)
                {
                    case 1:
                        admin adminWindow = new admin();
                        adminWindow.Show();
                        break;
                    case 2:
                        kassir kassirWindow = new kassir();
                        kassirWindow.Show();
                        break;
                    case 3:
                        user userWindow = new user();
                        userWindow.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте снова.");
            }
        } 
    }
}
