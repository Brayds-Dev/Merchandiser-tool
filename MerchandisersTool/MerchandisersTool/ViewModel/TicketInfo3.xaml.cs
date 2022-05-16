using SQLite;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MerchandisersTool.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketInfo3 : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        string elapsedTime;
        Models.Ticket ticket = new Models.Ticket();



        Stopwatch stopwatch;
        public TicketInfo3()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            ticketInfo.ItemsSource = db.Query<Models.Ticket>("select * from ticket where ticketId=3");
            stopwatch = new Stopwatch();
            ticketInfo.ItemSelected += TicketInfo_ItemSelected;
        }

        private void TicketInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ticket = (Models.Ticket)e.SelectedItem;
            _ticketId.Text = ticket.ticketId.ToString();
            _displayName.Text = ticket.displayName;
            _clientName.Text = ticket.store;
            _location.Text = ticket.location;
            _duration.Text = ticket.duration;
            _note.Text = ticket.note;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeSpan ts = stopwatch.Elapsed;

                elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                _timer.Text = elapsedTime;

                return true;
            }
                );
            DisplayAlert("Warning", "Job timer has started", "OK");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            stopwatch.Stop();
            btnStart.Text = "Resume";
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);


            Models.Ticket ticket = new Models.Ticket()
            {
                ticketId = Convert.ToInt32(_ticketId.Text),
                displayName = _displayName.Text,
                store = _clientName.Text,
                location = _location.Text,
                duration = elapsedTime,
                note = _note.Text
            };
            db.Update(ticket);
            stopwatch.Reset();
            btnStart.Text = "Start";
            await DisplayAlert("Warning", "Job completed, are you sure?", "OK");
            await Navigation.PopAsync();
        }

        private void noteBtn_Clicked(object sender, EventArgs e)
        {
            popupNote.IsVisible = true;

        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);


            Models.Ticket ticket = new Models.Ticket()
            {
                ticketId = Convert.ToInt32(_ticketId.Text),
                displayName = _displayName.Text,
                store = _clientName.Text,
                location = _location.Text,
                duration = elapsedTime,
                note = _note.Text
            };
            db.Update(ticket);



            await DisplayAlert("Alert", "Note saved", "OK");
            popupNote.IsVisible = false;
            await Navigation.PopAsync();

        }
    }
}