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
                    if (establishmentPicker.IsFocused)
                        establishmentPicker.Unfocus();
                    else
                        establishmentPicker.Focus();
                })
            };

            var tapCuisine = new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    if (cuisinePicker.IsFocused)
                        cuisinePicker.Unfocus();
                    else
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

            cuisinePicker
                .Focused += Picker_Focused;
            establishmentPicker
                .Focused += Picker_Focused;

            cuisinePicker
                .Unfocused += Picker_Unfocused;
            establishmentPicker
                .Unfocused += Picker_Unfocused;

            cuisinePicker
                .SelectedIndexChanged += CuisinePicker_SelectedIndexChanged;
            establishmentPicker
                .SelectedIndexChanged += EstablishmentPicker_SelectedIndexChanged;
        }

        async void Picker_Unfocused(object sender, EventArgs e)
        {
            cuisineLabel.IsEnabled = true;
            establishmentLabel.IsEnabled = true;
            establishmentSplit.IsEnabled = true;

            await mainLayout.FadeTo(1.0, 300, Easing.SinOut);
        }

        async void Picker_Focused(object sender, EventArgs e)
        {
            cuisineLabel.IsEnabled = false;
            establishmentLabel.IsEnabled = false;
            establishmentSplit.IsEnabled = false;

            await mainLayout.FadeTo(0.25, 300, Easing.SinIn);
        }

        void EstablishmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (establishmentPicker.SelectedIndex != 0) 
            {
                establishmentSplit.IsVisible = false;
                establishmentLabel
                    .Text = establishmentPicker.SelectedItem.ToString();
            }
            else 
            {
                establishmentSplit.IsVisible = true;
                establishmentLabel.Text = "любом";
            }
        }

        void CuisinePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuisineLabel
                .Text = $"{cuisinePicker.SelectedItem.ToString()} кухни";
        }
    }
}
