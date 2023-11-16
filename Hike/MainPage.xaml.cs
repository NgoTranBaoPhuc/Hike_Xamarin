using SQLite;
using Hike.Model;

namespace Hike
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                hikeColletion.ItemsSource = await App.MyDatabase.ReadHike(); 
            }
            catch (Exception ex)
            {

            }
        }

        private async void SwipeItem_Invoke_Edit(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as HikeModel;
            await Navigation.PushAsync(new HikeList(emp));
        }


        private async void SwipeItem_Invoke_Delete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as HikeModel;
            var result = await DisplayAlert("Delete", $"Delete {emp.name} from database", "yes", "no");
            if (result)
            {
                await App.MyDatabase.DeleteHike(emp);
                hikeColletion.ItemsSource = await App.MyDatabase.ReadHike();
            }
        }


        private async void SwipeItem_Invoked_Detail(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as HikeModel;

            await Navigation.PushAsync(new HikeDetail(emp));
        }


        private async void SearchBar_TextChange(object sender, TextChangedEventArgs e)
        {
            hikeColletion.ItemsSource = await App.MyDatabase.Search(e.NewTextValue);
        }

        private async void ToolbarItem_Clicked_AddHike(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HikeList());
        }
    }
}