using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MerchandisersTool.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTicket : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        public AddTicket()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.Ticket>();

            var maxpk = db.Table<Models.Ticket>().OrderByDescending(c => c.ticketId).FirstOrDefault();

            Models.Ticket ticket = new Models.Ticket()
            {
                ticketId = maxpk == null ? 1 : maxpk.ticketId + 1,
                displayName = _displayName.Text,
                store = _clientName.Text,
                location = _location.Text,
                duration = _duration.Text,
                note = _note.Text
               
            };
            db.Insert(ticket);
            await DisplayAlert(null, ticket.displayName + " " + "saved", "OK");
            await Navigation.PopAsync();
        }
    }
}