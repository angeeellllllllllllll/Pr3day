using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;
using WpfApp1.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = pass.Text;
            var context = new AppDbContext();
            var user_exist = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user_exist is null)
            {
                MesBox1.Text="Неправильный  логин или пароль";
                return;
            }
            MesBox1.Text ="Вы успешно вошли в аккаунт";
            this.Hide();
            Window1 window1 = new Window1();
            window1.Show();
            window1.MesBox2.Text = $"hello {log.Text}";
            

        }

        private void ToReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void pass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
