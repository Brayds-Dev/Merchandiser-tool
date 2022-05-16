using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MerchandisersTool.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewClient : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        public ViewClient()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            clientList.ItemsSource = db.Table<Models.Client>().OrderBy(x => x.clientName).ToList();

        }



        private async void Add_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClient());
        }

        private async void Remove_Activated(object sender, EventArgs e)
        {

            var db = new SQLiteConnection(_dbPath);
            //db.Table<Models.Client>().Delete(x == clientList.SelectedItem);
            db.Delete(clientList.SelectedItem);
            await Navigation.PopAsync();

        }

        private async void Update_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateClientDetail());
        }
    }
}