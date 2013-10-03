using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using FreeFoodEngine.ViewModels;

using SQLite;
using System.IO;
using Windows.Storage;
using System.Collections;

namespace FreeFoodEngine
{
    public partial class CalendarPage : PhoneApplicationPage
    {
        SampleAppointmentSource appointmentsSource = new SampleAppointmentSource();

        public CalendarPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(FirstLook_Loaded);

            loadData();
        }

        private async void loadData()
        {
            //SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);

            
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            conn.DropTableAsync<SampleAppointment>();

            await conn.CreateTableAsync<SampleAppointment>();

            DateTime temp = DateTime.Now;

            DateTime start = DateTime.Parse("06/08/2013 6:00 PM");
            DateTime end = DateTime.Parse("06/09/2013 6:00 PM");

            SampleAppointment appointment1 = new SampleAppointment
            {
                Subject = "MACF - App Camp",
                AdditionalInfo = "BRTN 291, RSVP Reguired",
                StartDate = start,
                EndDate = end
            };

            conn.InsertAsync(appointment1);

            SampleAppointment appointment2 = new SampleAppointment
            {
                StartDate = DateTime.Now.AddMinutes(30),
                EndDate = DateTime.Now.AddHours(1),
                Subject = "Appointment 376",
                AdditionalInfo = "Info 3"
            };

            conn.InsertAsync(appointment2);

            start = DateTime.Parse("06/05/2013 5:00 PM");
            end = DateTime.Parse("06/05/2013 6:00 PM");
            SampleAppointment appointment3 = new SampleAppointment
            {
                StartDate = DateTime.Now.AddHours(2),
                EndDate = DateTime.Now.AddHours(3),
                Subject = "Appointment uhy4",
                AdditionalInfo = "Info 4"
            };

            conn.InsertAsync(appointment3);

            SampleAppointment appointment4 = new SampleAppointment
            {
                Subject = "Malaysian Night",
                AdditionalInfo = "STEW Common, Members Only",
                StartDate = start,
                EndDate = end
            };

            conn.InsertAsync(appointment4);

            //this.OnDataLoaded();
        }




        void FirstLook_Loaded(object sender, RoutedEventArgs e)
        {
            //loadData();
            DisplayAppointmentsForDate(DateTime.Now.Date);

        }

        private async void DisplayAppointmentsForDate(DateTime date)
        {
            //appointmentsSource.FetchData(date, date.AddDays(1));

            //this.AppointmentsList.ItemsSource = appointmentsSource.GetAppointments((IAppointment appointment) =>
            //{
            //    DateTime currentAppointmentStart = appointment.StartDate;
            //    DateTime currentAppointmentEnd = appointment.EndDate;
            //    DateTime requiredAppointmentsStartDate = date.Date;
            //    DateTime requiredAppointmentsEndDate = date.Date.AddDays(1);

            //    if (requiredAppointmentsEndDate > currentAppointmentStart && requiredAppointmentsStartDate < currentAppointmentEnd)
            //    {
            //        return true;
            //    }

            //    return false;
            //});


            //retreieve data from database
            DateTime startDate = date;
            DateTime endDate = date.AddDays(1);
            

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            var query = conn.Table<SampleAppointment>().Where(x => x.StartDate >= startDate).Where(y => y.EndDate <= endDate);

            //IList<Appointment> = await query.ToListAsync();
            List<SampleAppointment> result2 = await query.ToListAsync();
            this.AppointmentsList.ItemsSource = result2;

            result2.Clear();
            //foreach (SampleAppointment appointment2 in result2)
            //{
            //    this.AppointmentsList.ItemsSource = appointmentsSource.GetAppointments((IAppointment appointment) =>
            //    {
            //        DateTime currentAppointmentStart = appointment2.StartDate;
            //        DateTime currentAppointmentEnd = appointment2.EndDate;
            //        DateTime requiredAppointmentsStartDate = date.Date;
            //        DateTime requiredAppointmentsEndDate = date.Date.AddDays(1);

            //        if (requiredAppointmentsEndDate > currentAppointmentStart && requiredAppointmentsStartDate < currentAppointmentEnd)
            //        {
            //            return true;
            //        }

            //        return false;
            //    });

            //}
        }

        private void RadCalendar_SelectedValueChanged(object sender, ValueChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                this.AppointmentsList.ItemsSource = null;
                return;
            }
            DisplayAppointmentsForDate((e.NewValue as DateTime?).Value);
        }

        private void RadCalendar_DisplayDateChanged_1(object sender, ValueChangedEventArgs<object> e)
        {

        }

        private void txtLogOut_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute)); 
        }
    }
}
