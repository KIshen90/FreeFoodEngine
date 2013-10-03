using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using System.IO;
using Windows.Storage;

namespace FreeFoodEngine
{
    public partial class RegisterForm : PhoneApplicationPage
    {
        public RegisterForm()
        {
            InitializeComponent();

            CreateDatabase();
        }

        public async void CreateDatabase()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "User.db"), true);
            await conn.CreateTableAsync<User>();

            SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            await conn1.CreateTableAsync<Appointment>();

        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Enter Credentials Here
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                txtRegError.Text = "Please enter a User Name.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }
            if (String.IsNullOrEmpty(txtRegPassword.Password))
            {
                txtRegError.Text = "Please enter a Password.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }
            if (String.IsNullOrEmpty(txtRegPasswordRe.Password))
            {
                txtRegError.Text = "Please enter a Password.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            if (txtRegPassword.Password != txtRegPasswordRe.Password)
            {
                txtRegError.Text = "Password does not math.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            if (String.IsNullOrEmpty(txtRegEmail.Text))
            {
                txtRegError.Text = "Please enter an Email Address.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            string email = txtRegEmail.Text;
            if (!email.Contains('@') || !email.Contains('.'))
            {
                txtRegError.Text = "Email entered is not valid.";
                txtRegError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "User.db"), true);

            User user = new User
            {
                userName = txtRegUserName.Text,
                emailAdd = txtRegEmail.Text,
                password = txtRegPassword.Password
            };

            await conn.InsertAsync(user);

            
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }

        [MaxLength(30)]
        public string userName { get; set; }

        [MaxLength(30)]
        public string emailAdd { get; set; }

        [MaxLength(30)]
        public string password { get; set; }
    }

    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int appID { get; set; }

        public int userID { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(50)]
        public string AdditionalInfo { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }
    }
}