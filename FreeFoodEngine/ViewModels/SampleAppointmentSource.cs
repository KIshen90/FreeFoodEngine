using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

using SQLite;
using System.IO;
using Windows.Storage;
using System.Collections;
using System.Collections.Generic;

namespace FreeFoodEngine.ViewModels
{
    public class SampleAppointmentSource : AppointmentSource
    {
        public SampleAppointmentSource()
        {
            loadData();
        }

        private async void loadData()
        {
            //SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
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
        

        public async override void FetchData(DateTime startDate, DateTime endDate)
        {
            //this.AllAppointments.Clear();

            //SQLiteAsyncConnection conn = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            //var query = conn.Table<SampleAppointment>().Where(x => x.StartDate >= startDate).Where(y => y.EndDate <= endDate);

            ////IList<Appointment> = await query.ToListAsync();
            //var result2 = await query.ToListAsync();

            //foreach (var items in result2)
            //{
            //    this.AllAppointments.Add(new SampleAppointment()
            //    {
            //        StartDate = items.StartDate,
            //        EndDate = items.EndDate,
            //        Subject = items.Subject,
            //        AdditionalInfo = items.AdditionalInfo
            //    });
            //}

            this.AllAppointments.Clear();

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.Now.AddHours(1),
            //    Subject = "Appointment 1",
            //    AdditionalInfo = "Info 1"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddMinutes(30),
            //    EndDate = DateTime.Now.AddHours(1),
            //    Subject = "Appointment 2",
            //    AdditionalInfo = "Info 2"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddMinutes(30),
            //    EndDate = DateTime.Now.AddHours(1),
            //    Subject = "Appointment 3",
            //    AdditionalInfo = "Info 3"

            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddHours(2),
            //    EndDate = DateTime.Now.AddHours(3),
            //    Subject = "Appointment 4",
            //    AdditionalInfo = "Info 4"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(1),
            //    EndDate = DateTime.Now.AddDays(1).AddHours(1),
            //    Subject = "Check scores",
            //    AdditionalInfo = "Info"
            //});
            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(1),
            //    EndDate = DateTime.Now.AddDays(3),
            //    Subject = "Long run",
            //    AdditionalInfo = "10 miles"
            //});
            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.Date.AddDays(6),
            //    EndDate = DateTime.Now.Date.AddDays(7),
            //    Subject = "Long run",
            //    AdditionalInfo = "15 miles"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(4),
            //    EndDate = DateTime.Now.AddDays(4).AddHours(1),
            //    Subject = "Go to cinema",
            //    AdditionalInfo = "Choose a movie first"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(-1),
            //    EndDate = DateTime.Now.AddDays(-1).AddHours(1),
            //    Subject = "Wash the car",
            //    AdditionalInfo = "If necessary"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(7),
            //    EndDate = DateTime.Now.AddDays(7).AddHours(1),
            //    Subject = "Sail the boat"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(7),
            //    EndDate = DateTime.Now.AddDays(7).AddHours(1),
            //    Subject = "Feed the fish"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddDays(8),
            //    EndDate = DateTime.Now.AddDays(8).AddHours(1),
            //    Subject = "Go to ski"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddMonths(1),
            //    EndDate = DateTime.Now.AddMonths(1).AddHours(12),
            //    Subject = "Go fishing"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddMonths(1),
            //    EndDate = DateTime.Now.AddMonths(1).AddHours(12),
            //    Subject = "Go to MIX"
            //});

            //this.AllAppointments.Add(new SampleAppointment()
            //{
            //    StartDate = DateTime.Now.AddMonths(1),
            //    EndDate = DateTime.Now.AddMonths(1).AddHours(12),
            //    Subject = "Visit Kauai"
            //});

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "Appointment.db"), true);
            var query = conn.Table<SampleAppointment>().Where(x => x.StartDate >= startDate).Where(y => y.EndDate <= endDate);

            //IList<Appointment> = await query.ToListAsync();
            List<SampleAppointment> result2 = await query.ToListAsync();

            foreach (SampleAppointment items in result2)
            {
                this.AllAppointments.Add(new SampleAppointment()
                {
                    StartDate = items.StartDate,
                    EndDate = items.EndDate,
                    Subject = items.Subject,
                    AdditionalInfo = items.AdditionalInfo
                });

            }

            //this.OnDataLoaded();

            //this.DataLoaded();
            this.OnDataLoaded();
        }
    }

    public class SampleAppointment : IAppointment
    {
        public DateTime EndDate
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string AdditionalInfo
        {
            get;
            set;
        }
    }
}
