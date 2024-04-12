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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();


            RoleBox.SelectedIndex = 0;

            var context = new AppDbContext();
            var users = context.Users.ToList();

            string AllUsers = string.Join(Environment.NewLine, users.Select(u => $"ID: {u.Id}, Логин: {u.Login}"));

            UsersAll.Text = "Список всех пользователей:" + Environment.NewLine + AllUsers;

            foreach (var user in users)
            {
                RoleBox.Items.Add(user.Login);
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RoleBox.SelectedIndex == 0)
            {
                MessageBox.Show("Вы не выбрали пользователя!");
            }
            else
            {
                if (LoginEdit is not null && PassEdit is not null && MailEdit is not null)
                {

                    var login = RoleBox.Text;
                    var x = Convert.ToInt32(RoleBox.Text);
                    var context = new AppDbContext();

                    var user = context.Users.FirstOrDefault(u => u.Login == login);

                    user.Login = LoginEdit.Text;
                    user.Email = MailEdit.Text;
                    user.Password = PassEdit.Text;
                    context.SaveChanges();
                    MessageBox.Show("ОК!");



                    LoginEdit.Text = "";
                    MailEdit.Text = "";
                    PassEdit.Text = "";
                    var users = context.Users.ToList();

                    string AllUsers = string.Join(Environment.NewLine, users.Select(u => $"ID: {u.Id}, Логин: {u.Login}"));

                    UsersAll.Text = "Список всех пользователей:" + Environment.NewLine + AllUsers;

                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Выбрать пользователя");
                    RoleBox.SelectedIndex = 0;

                    foreach (var user1 in users)
                    {
                        RoleBox.Items.Add(user1.Login);
                    }
                }
                else
                {
                    {
                        MessageBox.Show("Вы ввели не все данные!");
                    }
                }
            }

        }
    }
}

