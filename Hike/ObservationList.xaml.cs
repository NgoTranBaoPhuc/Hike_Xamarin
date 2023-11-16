using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hike.Model;





namespace Hike
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObservationList : ContentPage
    {
        private int hikeId = 0;
        public ObservationList()
        {
            InitializeComponent();
        }

        public ObservationList(int hike)
        {
            InitializeComponent();
            hikeId = hike;
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            AddObservation();
        }

        private async void EditObservation()
        {

        }
        private async void AddObservation()
        {
            await App.MyDatabase.CreateObservation(new ObservationModel
            {
                name = txtObservation.Text,
                //time = dtpObservationTime.,
                comment = txtComment.Text,
                HikeFk = hikeId

            });
            await Navigation.PopAsync();


        }
    }
}

