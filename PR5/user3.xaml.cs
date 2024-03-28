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
using System.Xml.Linq;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для user3.xaml
    /// </summary>
    public partial class user3 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public user3()
        {
            InitializeComponent();
            us3.ItemsSource = context.StatusTicket.ToList();
            orders.ItemsSource = context.TicketOrders.ToList();
            orders.DisplayMemberPath = "TicketCount";
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(status.Text) ||
                orders.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }
            if (status.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Статус должен состоять только из букв.");
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

            StatusTicket c = new StatusTicket();

            c.Status = status.Text;
            c.TicketOrdersID = (orders.SelectedItem as TicketOrders).ID_TicketOrders;


            context.StatusTicket.Add(c);

            context.SaveChanges();
            us3.ItemsSource = context.StatusTicket.ToList();
        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (us3.SelectedItems != null)
            {
                var selected = us3.SelectedItem as StatusTicket;


                selected.Status = status.Text;
                selected.TicketOrdersID = (orders.SelectedItem as TicketOrders).ID_TicketOrders;


                context.SaveChanges();
                us3.ItemsSource = context.StatusTicket.ToList();
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            } 

            if (us3.SelectedItem != null)
            {
                context.StatusTicket.Remove(us3.SelectedItem as StatusTicket);

                context.SaveChanges();
                us3.ItemsSource = context.StatusTicket.ToList();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void us3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (us3.SelectedItems != null)
            {
                var selected = us3.SelectedItem as StatusTicket;

                if (selected != null)
                {
                    status.Text = selected.Status;
                    orders.Text = selected.TicketOrdersID.ToString();

                }
            }
        }
    }
}
