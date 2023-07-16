using AuthWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AuthWPF
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private Repository repos;
        public RegisterWindow()
        {
            InitializeComponent();
            repos = new Repository();  
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow form = new LoginWindow();
            form.Show();
            Close();
        }
        private void ResetWindow()
        {
            errormessage.Text = "";
            textBoxUserName.Text= "";
            textBoxEmail.Text = "";
            passwordBox.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxUserName.Text;
            string email = textBoxEmail.Text;
            string password = passwordBox.Password;
            if (repos.CheckValidateEmail(textBoxEmail, errormessage) == true 
                && repos.CheckValidatePassword(passwordBox, passwordBoxConfirm, errormessage) == true 
                && repos.CheckValidatePassword(passwordBox, errormessage) == true)
            {
                ResetWindow();
                repos.AddUser(new User { Name = name, Email = email, Password = password });
                errormessage.Text = "Вы зарегистрированы!";
            }

        }
    }
}
