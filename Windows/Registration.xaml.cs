using Microsoft.Windows.Themes;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = Pass.Text;
            var email = mail.Text;
            var context = new AppDbContext();
            var user_exist = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if ((!Regex.IsMatch(email, @"^[a-zA-z0-9_.+-]+@(mail\.ru|gmail.com|yandex\.ru)$")))
            {
                MesBox.Text = "Указан неверный email!";
                error1.Visibility = Visibility.Visible;
            }
            else if (((!Regex.IsMatch(password, @"[!,&%+_]"))))
            {
                error1.Visibility = Visibility.Collapsed;
                error2.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "В пароле требуются спец. символы!";
            }
            else if (Pass.Text.Length < 8)
            {
                error2.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "Данный пароль является ненадёжным!";

            }
            else if (Pass.Text != pass2.Text)
            {
                error2.Visibility = Visibility.Collapsed;
                error3.Visibility = Visibility.Visible;
                MesBox.Text = "";
                MesBox.Text = "Пароли не совпадают!";

            }



            else if (user_exist is not null)
            {

                error2.Visibility = Visibility.Visible;
                error3.Visibility = Visibility.Collapsed;
                MesBox.Text = "";
                MesBox.Text = "Такой пользователь уже существует";
                return;
            }
            else 
                {

                var user = new User { Login = login, Password = password, Email = email };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Добро пожаловать!");
            }

        }

        private void voitiBut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
           
        }

        private void Pass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
