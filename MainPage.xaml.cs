using System.Collections.ObjectModel;

namespace HikeManagement
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        App thisApp = Microsoft.Maui.Controls.Application.Current as App;
        private MySQLiteDatabase myDB;

        public MainPage()
        {
            InitializeComponent();
            thisApp.HikeList = new ObservableCollection<Hike>();
            myDB = new MySQLiteDatabase();
        }


        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm", "Are you sure you want to submit?", "Yes", "No");
            if (response)
            {
                Hike h = new Hike(count++, this.txtName.Text, this.txtLocation.Text, this.dtpDate.Date, this.swtParking.IsToggled, this.txtDistance.Text, this.cbxDifficulty.ToString(), this.txtDescription.Text, this.txtAccomodation.Text);
                thisApp.HikeList.Add(h);
                myDB.AddHike(h);
                await DisplayAlert("Success", "Hike added successfully", "OK");
            }
        }

        private void btnList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HikeList(),true);
        }

        private void btnLoad_Hike_Clicked(object sender, EventArgs e)
        {
            thisApp.HikeList = myDB.GetAllHikes();
        }
    }

}
