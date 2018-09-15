using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Voglio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var tapEstablishment = new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    establishmentPicker.Focus();
                })
            };

            var tapCuisine = new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    cuisinePicker.Focus();
                })
            };

            establishmentLabel
                .GestureRecognizers
                .Add(tapEstablishment);

            establishmentSplit
                .GestureRecognizers
                .Add(tapEstablishment);

            cuisineLabel
                .GestureRecognizers
                .Add(tapCuisine);

            establishmentPicker
                .SelectedIndexChanged += EstablishmentPicker_SelectedIndexChanged;
        }

        void EstablishmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (establishmentPicker.SelectedIndex != 0) 
            {
                establishmentSplit.IsVisible = false;
                establishmentLabel.Text = establishmentPicker
                    .SelectedItem
                    .ToString();
            }
            else 
            {
                establishmentSplit.IsVisible = true;
                establishmentLabel.Text = "любом";
            }
        }
    }
}
