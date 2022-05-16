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
    public partial class ViewMerch : ContentPage
    {
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "test.db3");
        public ViewMerch()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            merchList.ItemsSource = db.Table<Models.Merchandiser>().OrderBy(x => x.firstName).ToList();
        }

        private async void Add_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMerch());
        }

        private async void Remove_Activated(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            //db.Table<Models.Merchandisert>().Delete(x == merchList.SelectedItem);
            db.Delete(merchList.SelectedItem);
            await Navigation.PopAsync();
        }

        private async void Update_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateMerchDetail());
        }
    }
}