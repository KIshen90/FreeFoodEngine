       using System; using System.Collections.Generic; using System.Linq; using System.Net; using System.Windows; using System.Windows.Controls; using System.Windows.Documents; using System.Windows.Input; using System.Windows.Media; using System.Windows.Media.Animation; using System.Windows.Shapes; using Microsoft.Phone.Controls;  namespace FreeFoodEngine.ViewModels {     public partial class OptionsPage : PhoneApplicationPage     {         public OptionsPage()         {             InitializeComponent();         }

        private void bxCalendarView_DoubleTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CalendarPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadCustomHubTile_DoubleTap_1(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModels/AboutPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadCustomHubTile_DoubleTap_2(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModels/SubmitEventPage.xaml", UriKind.RelativeOrAbsolute));
        }
             } } 