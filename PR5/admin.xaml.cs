using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();

        public admin()
        {
            InitializeComponent();
            ad0.ItemsSource = context.Roles.ToList();
        }

        private bool ValidateFields(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Пожалуйста, заполните название роли.");
                return false;
            }

            if (roleName.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Название роли может содержать только буквы и цифры.");
                return false;
            }

            return true;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields(A0.Text))
            {
                return;
            }

            Roles c = new Roles();
            c.RoleName = A0.Text;

            context.Roles.Add(c);

             context.SaveChanges();
            ad0.ItemsSource = context.Roles.ToList();

        }

        

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields(A0.Text))
            {
                return;
            }

            if (ad0.SelectedItem != null)
            { 
                
            
                var selected = ad0.SelectedItem as Roles;

               selected.RoleName = A0.Text;

                context.SaveChanges();
                ad0.ItemsSource = context.Roles.ToList();
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields(A0.Text))
            {
                return;
            }

            if (ad0.SelectedItem != null)
            {
                context.Roles.Remove(ad0.SelectedItem as Roles);

                context.SaveChanges();
                ad0.ItemsSource = context.Roles.ToList();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin1 ad0Window = new admin1();
            ad0Window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            admin2 ad0Window = new admin2();
            ad0Window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            admin3 ad0Window = new admin3();
            ad0Window.ShowDialog();
        }

        private void ad0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ad0.SelectedItems != null)
            {
                var selected = ad0.SelectedItem as Roles;

                if (selected != null)
                {
                    A0.Text = selected.RoleName;
                   
                }
            }
        }
    }
}
