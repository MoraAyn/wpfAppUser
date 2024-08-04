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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace usersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppCon bd;
        AuthWin authwin = new AuthWin();
        public MainWindow()
        {
            InitializeComponent();
            bd = new AppCon();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string loginT = loginUser.Text.Trim();
            string passwordT = passUser.Password.Trim();
            string repeat_passwordT = repeatPassUser.Password.Trim();
            string emailT = emailUser.Text.Trim().ToLower(); // в нижний регистр

            if(loginT.Length < 5)
            {
                loginUser.ToolTip = "Логин должен содержать более 5 букв";
                loginUser.Background = Brushes.DarkRed;
            } else if(passwordT.Length < 6) {
                passUser.ToolTip = "Пароль должен содержать более 6 символов";
                passUser.Background = Brushes.DarkRed;
            } else if(repeat_passwordT != passwordT)
            {
                repeatPassUser.ToolTip = "Пароли не совпадают";
                repeatPassUser.Background = Brushes.DarkRed;
            } else if(emailT.Length < 5 || !emailT.Contains("@") || !emailT.Contains(".")) // если email не содержит @ || .
            {
                emailUser.ToolTip = "Введите корректный email";
                emailUser.Background = Brushes.DarkRed;
            } else
            {
                loginUser.ToolTip = "";
                loginUser.Background = Brushes.Transparent;

                passUser.ToolTip = "";
                passUser.Background = Brushes.Transparent;

                repeatPassUser.ToolTip = "";
                repeatPassUser.Background = Brushes.Transparent;

                emailUser.ToolTip = "";
                emailUser.Background = Brushes.Transparent;

                User user = new User(loginT, emailT, passwordT);
                bd.Users.Add(user); // -> AppCon.cs -> благодаря DbSet мы по факту напрямую взаимодействуем с БД
                bd.SaveChanges(); //login, email, password

               
                authwin.Show();
                this.Close();
            }
        }

        private void Button_vhodToAuthWin_Click(object sender, RoutedEventArgs e)
        {
            authwin.Show();
            this.Close();
        }
    }
}
