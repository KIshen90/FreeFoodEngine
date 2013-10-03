using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FreeFoodEngine.Resources;

using SQLite;
using System.IO;
using System.Collections;
using Windows.Storage;

namespace FreeFoodEngine
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            CreateDatabase();


            ResetPage();
        }

        public async void CreateDatabase()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "User.db"), true);
            await conn.CreateTableAsync<User>();

            SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            await conn1.CreateTableAsync<Appointment>();

        }

        private void ResetPage()
        {
            txtError.Text = "";
            txtError.Visibility = System.Windows.Visibility.Collapsed;

            txtEmail.Text = "";
            txtPassword.Password = "";
        }

        private void txtNewUser_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

        private void txtNewUser_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RegisterForm.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Authenticate Credentials here
            txtError.Text = "";
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                txtError.Text = "Please enter a valid Email.";
                txtError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            string email = txtEmail.Text;
            if (!email.Contains('@') || !email.Contains('.'))
            {
                txtError.Text = "Email entered is not valid.";
                txtError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            if (String.IsNullOrEmpty(txtPassword.Password.ToString()))
            {
                txtError.Text = "Please enter a password.";
                txtError.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "User.db"), true);
            string useremail = txtEmail.Text;
            string userpassword = txtPassword.Password;

            try
            {
                var query = conn.Table<User>().Where(x => x.emailAdd == useremail).Where(y => y.password ==  userpassword) ;
                //User result = await query.FirstAsync();
                //int result = await query.CountAsync();
                List<User> result = await query.ToListAsync();

                if (result.Count <= 0)
                {
                    txtError.Text = "No Email Found. Please register.";
                    txtError.Visibility = System.Windows.Visibility.Visible;

                    return;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/ViewModels/OptionsPage.xaml", UriKind.RelativeOrAbsolute));
                }
            }
            catch
            {

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

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}