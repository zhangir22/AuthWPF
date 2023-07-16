using AuthWPF.Models;
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

namespace AuthWPF
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Repository repos;
        public LoginWindow()
        {
            InitializeComponent();
            repos = new Repository();
        }
        private void ToRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow form = new RegisterWindow();
            form.Show();
            Close();
        }
        private void ResetWindow()
        {
            textBoxUserName.Text = "";
            passwordBox.Password = "";
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxUserName.Text;
            if (repos.CheckValidatePassword(passwordBox,errormessage) == true)
            {
                ResetWindow();
                User user = repos.FindUserByName(name);
                if (user == null)
                {
                    errormessage.Text = "Такой пользователь не сущетсвует!";
                }else
                    errormessage.Text = "Вы Зашли!";
            }
        }
    }
}
