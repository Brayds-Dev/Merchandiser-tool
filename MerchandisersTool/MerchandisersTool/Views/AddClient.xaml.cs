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
    public partial class AddClient : ContentPage
    {
        //Provide path for local database
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        public AddClient()
        {
            InitializeComponent();
        }

        
        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.Client>();

            var maxpk = db.Table<Models.Client>().OrderByDescending(c => c.clientId).FirstOrDefault();

            Models.Client client = new Models.Client()
            {
                clientId = maxpk == null ? 1 : maxpk.clientId + 1,
                clientName = _nameEntry.Text,
                location = _locationEntry.Text,
                phoneNo = _phoneNo.Text
            };
            db.Insert(client);
            await DisplayAlert(null, client.clientName + " " + "saved", "OK");
            await Navigation.PopAsync();
        }
    }
}