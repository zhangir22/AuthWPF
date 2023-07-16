using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AuthWPF.Models
{
    public class Repository
    {
        private Context db { get; set; }
        public Repository()
        {
            db = new Context();
        }
        public List<User> GetAllUsers()
        {
            return db.users.ToList();
        }
        public User FindUserByName(string name)
        {
            return db.users.FirstOrDefault(x => x.Name == name);
        }
        public User FindUserById(int id)
        {
            return db.users.FirstOrDefault(c => c.Id == id);
        }
        public void AddUser(User user)
        {
            if(user != null)
            {
                
                if (db.users.FirstOrDefault(c=> c.Name == user.Name && c.Password == user.Password) == null)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                }
            }
        }
        public bool CheckValidateEmail(TextBox textBoxEmail, TextBlock errormessage)
        {
            string email = textBoxEmail.Text;
            if (email.Length == 0)
            {
                errormessage.Text = "Напишите Email";
                textBoxEmail.Focus();
                return false;
            }
            else if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errormessage.Text = "Напишите нормальный Email";
                textBoxEmail.Select(0, email.Length);
                textBoxEmail.Focus();
                return false;
            }
            return true;

        }
        public bool CheckValidatePassword(PasswordBox textBoxPassword, TextBlock errormessage) 
        {
            string password = textBoxPassword.Password;
                if (password.Length == 0)
                {
                    errormessage.Text = "Напишите пароль";
                    textBoxPassword.Focus();
                    return false;
                } 
            
            return true;
        }
        public bool CheckValidatePassword(PasswordBox textBoxPassword, PasswordBox passwordBoxConfirm, TextBlock errormessage)
        {
            string password = textBoxPassword.Password;
            if (passwordBoxConfirm.Password != password)
            {
                errormessage.Text = "Пароли не совпадают";
                textBoxPassword.Focus();
                return false;
            }
            return true;
        }

    }
}
