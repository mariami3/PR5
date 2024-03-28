using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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
    /// Логика взаимодействия для kassir1.xaml
    /// </summary>
    public partial class kassir1 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public kassir1()
        {
            InitializeComponent();
            ks1.ItemsSource = context.TicketOrders.ToList();
            session.ItemsSource = context.Sessions.ToList();
            session.DisplayMemberPath = "DateSession";
            orders.ItemsSource = context.SnackOrders.ToList();
            orders.DisplayMemberPath = "Quantity";
            worker.ItemsSource = context.Workers.ToList();
            worker.DisplayMemberPath = "Position";
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(session.Text) ||
                string.IsNullOrWhiteSpace(price.Text) ||
                string.IsNullOrWhiteSpace(orders.Text) ||
                string.IsNullOrWhiteSpace(count.Text) ||
                string.IsNullOrWhiteSpace(date.Text) ||
                string.IsNullOrWhiteSpace(status.Text) ||
                string.IsNullOrWhiteSpace(number.Text) ||
                string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(worker.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }

            if (!int.TryParse(number.Text, out _))
            {
               MessageBox.Show("Номер телефона должен состоять из чисел.");
               return false;
            }

            if (!int.TryParse(count.Text, out _))
            {
                MessageBox.Show("Количество билетов должен быть числом.");
                return false;
            }

            if (!DateTime.TryParseExact(date.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты и времени. Используйте формат yyyy-MM-dd HH:mm:ss");
                return false;
            }

            if (name.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Имя должно состоять только из букв.");
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

            if (int.TryParse(price.Text, out int parsedPrice) && int.TryParse(count.Text, out int parsedCount) &&
         parsedPrice > 0 && parsedCount > 0)
            {
                TicketOrders c = new TicketOrders();

                c.SessionID = (session.SelectedItem as Sessions).ID_Session;
                c.TicketPrice = parsedPrice;
                c.SnackOrdersID = (orders.SelectedItem as SnackOrders).ID_SnackOrders;
                c.TicketCount = parsedCount;
                c.DateTimeBroni = date.Text;
                c.StatusBooking = status.Text;
                c.PhoneNumber = number.Text;
                c.FirstName = name.Text;
                c.WorkerID = (worker.SelectedItem as Workers).ID_Worker;

                context.TicketOrders.Add(c);

                context.SaveChanges();
                ks1.ItemsSource = context.TicketOrders.ToList();
            }
            else
            {
                MessageBox.Show("Цена и количество должны быть положительными числами.");
            }
        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ks1.SelectedItems != null)
            {
                var selected = ks1.SelectedItem as TicketOrders;

                if (int.TryParse(price.Text, out int parsedPrice) && int.TryParse(count.Text, out int parsedCount) &&
                    parsedPrice > 0 && parsedCount > 0)
                {
                    selected.SessionID = (session.SelectedItem as Sessions).ID_Session;
                    selected.TicketPrice = parsedPrice;
                    selected.SnackOrdersID = (orders.SelectedItem as SnackOrders).ID_SnackOrders;
                    selected.TicketCount = parsedCount;
                    selected.DateTimeBroni = date.Text;
                    selected.StatusBooking = status.Text;
                    selected.PhoneNumber = number.Text;
                    selected.FirstName = name.Text;
                    selected.WorkerID = (worker.SelectedItem as Workers).ID_Worker;

                    context.SaveChanges();
                    ks1.ItemsSource = context.TicketOrders.ToList();
                }
                else
                {
                    MessageBox.Show("Цена и количество должны быть положительными числами.");
                }
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ks1.SelectedItems != null)
            {

                TicketOrders selectTicketOrders = (TicketOrders)ks1.SelectedItem;

                context.TicketOrders.Remove(selectTicketOrders);

                context.SaveChanges();
                ks1.ItemsSource = context.TicketOrders.ToList();

            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ks1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ks1.SelectedItems != null)
            {
                var selected = ks1.SelectedItem as TicketOrders;

                if (selected != null)
                {
                    session.Text = selected.SessionID.ToString();
                    price.Text = selected.TicketPrice.ToString();
                    orders.Text = selected.SnackOrdersID.ToString();
                    count.Text = selected.TicketCount.ToString();
                    date.Text = selected.DateTimeBroni;
                    status.Text = selected.StatusBooking;
                    number.Text = selected.PhoneNumber;
                    name.Text = selected.FirstName;
                    worker.Text = selected.WorkerID.ToString();
                }
            }
        }
    }
}
