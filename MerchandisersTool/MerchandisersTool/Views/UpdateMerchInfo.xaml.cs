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
    public partial class UpdateMerchDetail : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        Models.Merchandiser merchandiser = new Models.Merchandiser();
        public UpdateMerchDetail()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            merchList.ItemsSource = db.Table<Models.Merchandiser>().OrderBy(x => x.firstName).ToList();
            merchList.ItemSelected += MerchList_ItemSelected;
        }

        private void MerchList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            merchandiser = (Models.Merchandiser)e.SelectedItem;
            ID.Text = merchandiser.merchId.ToString();
            fName.Text = merchandiser.firstName;
            lName.Text = merchandiser.lastName;
            phoneNo.Text = merchandiser.merchPhoneNo;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Models.Merchandiser merchandiser = new Models.Merchandiser()
            {
                merchId = Convert.ToInt32(ID.Text),
                firstName = fName.Text,
                lastName = lName.Text,
                merchPhoneNo = phoneNo.Text,
            };
            db.Update(merchandiser);
            await DisplayAlert(null, "Data uptdated successfully", "OK");
            await Navigation.PopAsync();

        }
    }
}