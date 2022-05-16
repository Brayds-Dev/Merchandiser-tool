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
    public partial class TicketInfo : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");

        public TicketInfo()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            ticketInfo.ItemsSource = db.Table<Models.Ticket>().OrderBy(x => x.displayName).ToList();

        }

        private async void Remove_Activated(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            //db.Table<Models.Client>().Delete(x == clientList.SelectedItem);
            db.Delete(ticketInfo.SelectedItem);
            await Navigation.PopAsync();
        }
    }
}