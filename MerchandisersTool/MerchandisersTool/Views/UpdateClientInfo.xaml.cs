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
    public partial class UpdateClientDetail : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        Models.Client client = new Models.Client();
        public UpdateClientDetail()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            clientList.ItemsSource = db.Table<Models.Client>().OrderBy(x => x.clientName).ToList();
            clientList.ItemSelected += ClientList_ItemSelected;
        }

        private void ClientList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            client = (Models.Client)e.SelectedItem;
            ID.Text = client.clientId.ToString();
            name.Text = client.clientName;
            location.Text = client.location;
            phoneNo.Text = client.phoneNo;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Models.Client client = new Models.Client()
            {
                clientId = Convert.ToInt32(ID.Text),
                clientName = name.Text,
                location = location.Text,
                phoneNo = phoneNo.Text,
            };
            db.Update(client);
            await DisplayAlert(null, "Data updated successfully", "OK");
            await Navigation.PopAsync();
        }
    }
}