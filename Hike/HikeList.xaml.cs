using Hike.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hike
{
    public partial class HikeList : ContentPage
    {
        HikeModel _hike;
        public HikeList()
        {
            InitializeComponent();
        }

        public HikeList(HikeModel hike)
        {
            InitializeComponent();
            _hike = hike;
            txtHike.Text = hike.name;
            txtLocation.Text = hike.location;
            dtpDateofBirth.Date = hike.date;
            hike.isParking = hike.isParking;
            txtLength.Text = hike.length.ToString();
            cbxLevel.SelectedItem = hike.level;
            txtDescription.Text = hike.description;
            txtVehicle.Text = hike.vehicle;
            txtMember.Text = hike.member.ToString();


        }

       /* private async void btnSubmit_Clicker(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHike.Text))
            {
                await DisplayAlert("Invalid", "BLank or white space", "ok");
            }
            else if (_hike != null)
            {
                EditHike();
            }
            else
            {
                AddNewHike();
            }
        }*/

        async void EditHike()
        {
            _hike.name = txtHike.Text;
            _hike.location = txtLocation.Text;
            _hike.date = dtpDateofBirth.Date;
            _hike.isParking = 1;
            _hike.length = float.Parse(txtLength.Text);
            _hike.level = (string)cbxLevel.SelectedItem;
            _hike.description = txtDescription.Text;
            _hike.vehicle = txtVehicle.Text;
            _hike.member = int.Parse(txtMember.Text);

            await App.MyDatabase.UpdateHike(_hike);
            await Navigation.PopAsync();

        }

        async void AddNewHike()
        {
            
            await App.MyDatabase.CreateHike(new HikeModel
            {
                name = txtHike.Text,
                location = txtLocation.Text,
                date = dtpDateofBirth.Date,
                isParking = 1,
                length = float.Parse(txtLength.Text),
                level = (string)cbxLevel.SelectedItem,
                description = txtDescription.Text,
                vehicle = txtVehicle.Text,
                member = int.Parse(txtMember.Text),

            });
            await Navigation.PopAsync();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHike.Text))
            {
                DisplayAlert("Invalid", "BLank or white space", "ok");
            }
            else
            {
                AddNewHike();
            }
        }
    }
}

