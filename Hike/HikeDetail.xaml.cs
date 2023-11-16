using Hike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hike
{
    public partial class HikeDetail : ContentPage
    {
        private int HikeId;


        public HikeDetail()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                observationCollection.ItemsSource = await App.MyDatabase.ReadObservation(HikeId); ;
            }
            catch (Exception ex)
            {

            }
        }
        public HikeDetail(HikeModel hike)
        {
            InitializeComponent();
            Title = hike.name;
            namelbl.Text = hike.name;
            locationlbl.Text = hike.location;

            hike.isParking = hike.isParking;
            lengthlbl.Text = hike.id.ToString();
            lengthlbl.Text = hike.level;
            descriptionlbl.Text = hike.description;
            vehiclelbl.Text = hike.vehicle;
            memberlbl.Text = hike.member.ToString();

            //HikeId = hike.id;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ObservationList(HikeId));
        }
    }

}







