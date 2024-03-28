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
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using System.Globalization;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для kassir2.xaml
    /// </summary>
    public partial class kassir2 : Window
    {
        private CinemaEntities2 context = new CinemaEntities2();
        public kassir2()
        {
            InitializeComponent();
            ks2.ItemsSource = context.Payments.ToList();
            orders.ItemsSource = context.TicketOrders.ToList();
            orders.DisplayMemberPath = "TicketPrice";
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(orders.Text) ||
                string.IsNullOrWhiteSpace(pay.Text) ||
                string.IsNullOrWhiteSpace(amout.Text) ||
                string.IsNullOrWhiteSpace(date.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }

            if (!int.TryParse(amout.Text, out _))
            {
                MessageBox.Show("Сумма должна состоять из чисел.");
                return false;
            }
            if (!DateTime.TryParseExact(date.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты и времени. Используйте формат yyyy-MM-dd HH:mm:ss");
                return false;
            }
            if (pay.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Оплата должно состоять только из букв.");
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

            if (int.TryParse(amout.Text, out int parsedAmount) && parsedAmount > 0)
            {
                Payments c = new Payments();

                c.TicketOrdersID = (orders.SelectedItem as TicketOrders).ID_TicketOrders;
                c.PaymentMethod = pay.Text;
                c.Amount = parsedAmount;
                c.PaymentDateTime = date.Text;

                context.Payments.Add(c);

                context.SaveChanges();
                ks2.ItemsSource = context.Payments.ToList();
            }
            else
            {
                MessageBox.Show("Сумма  должна быть положительным числом.");
            }
        }

        private void UPDATE_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ks2.SelectedItems != null)
            {
                var selected = ks2.SelectedItem as Payments;

                // Проверяем, что Amount не равен нулю и не отрицателен
                if (int.TryParse(amout.Text, out int parsedAmount) && parsedAmount > 0)
                {
                    selected.TicketOrdersID = (orders.SelectedItem as TicketOrders).ID_TicketOrders;
                    selected.PaymentMethod = pay.Text;
                    selected.Amount = parsedAmount;
                    selected.PaymentDateTime = date.Text;

                    context.SaveChanges();
                    ks2.ItemsSource = context.Payments.ToList();
                }
                else
                {
                    MessageBox.Show("Сумма  должна быть положительным числом.");
                }
            }
        }

        private void DELETE_Click_2(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            if (ks2.SelectedItems != null)
            {

                Payments selectPayments = (Payments)ks2.SelectedItem;

                context.Payments.Remove(selectPayments);

                context.SaveChanges();
                ks2.ItemsSource = context.Payments.ToList();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ks2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ks2.SelectedItems != null)
            {
                var selected = ks2.SelectedItem as Payments;

                if (selected != null)
                {
                    orders.Text = selected.TicketOrdersID.ToString();
                    pay.Text = selected.PaymentMethod;
                    amout.Text = selected.Amount.ToString();
                    date.Text = selected.PaymentDateTime;
                }
            }
        }
    }
}
