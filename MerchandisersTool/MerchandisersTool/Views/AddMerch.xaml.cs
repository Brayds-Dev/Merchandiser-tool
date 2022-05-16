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
    public partial class AddMerch : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        public AddMerch()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.Merchandiser>();

            var maxpk = db.Table<Models.Merchandiser>().OrderByDescending(c => c.merchId).FirstOrDefault();

            Models.Merchandiser merchandiser = new Models.Merchandiser()
            {
                merchId = maxpk == null ? 1 : maxpk.merchId + 1,
                firstName = _fNameEntry.Text,
                lastName = _lNameEntry.Text,
                merchPhoneNo = _merchPhoneNo.Text
            };
            db.Insert(merchandiser);
            await DisplayAlert(null, merchandiser.firstName + " " + "saved", "OK");
            await Navigation.PopAsync();
        }
    }
}