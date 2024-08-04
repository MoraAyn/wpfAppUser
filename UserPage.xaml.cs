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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        MainWindow mainwin = new MainWindow();
        public UserPage()
        {
            InitializeComponent();

            AppCon db = new AppCon();
            List<User> users = db.Users.ToList();
            listUsers.ItemsSource = users;
        }

        private void ReturnToRegistration(object sender, RoutedEventArgs e)
        {
            mainwin.Show();
            this.Close();
        }
    }
}
