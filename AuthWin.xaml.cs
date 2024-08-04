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

namespace usersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
           
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string loginT = loginUser.Text.Trim();
            string passwordT = passUser.Password.Trim();

            if (loginT.Length < 5)
            {
                loginUser.ToolTip = "Логин должен содержать более 5 букв";
                loginUser.Background = Brushes.DarkRed;
            }
            else if (passwordT.Length < 6)
            {
                passUser.ToolTip = "Пароль должен содержать более 6 символов";
                passUser.Background = Brushes.DarkRed;
            } else
            {
                loginUser.ToolTip = "";
                loginUser.Background = Brushes.Transparent;

                passUser.ToolTip = "";
                passUser.Background = Brushes.Transparent;

                User authUser = null;
                using (AppCon con = new AppCon()) // мы подключаемся к бд с помощью класса AppCon и проверяем есть ли в полях таблицы совпадения с введенными данными
                {
                    authUser = con.Users.Where(userdata => userdata.Login == loginT && userdata.Password == passwordT).FirstOrDefault();
                }
                if(authUser != null) // если есть, то успешная авторизация
                {
                    UserPage user_page = new UserPage();
                    user_page.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("Вы не найдены");
                }
                
            }
        }

        private void Button_vhodToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwin = new MainWindow();
            mainwin.Show();
            this.Close();
        }
    }
}
