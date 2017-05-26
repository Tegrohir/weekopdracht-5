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

namespace ThatOneStore
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String Iname = textBoxName.Text;
            String Ipassword = passwordBox1.Password;
            String name = "test";
            String password = "test";
            if (Iname.Equals(name) && Ipassword.Equals(password))
            {
                Store store = new Store();
                store.Show();
                Close();
                //MessageBox.Show("Logged in!\nJust kidding. This is a really bad application, so we can't actually log you in yet. Better luck next time though!");
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stuff happened, you clicked register");
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
