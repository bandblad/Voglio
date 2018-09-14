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

            var tapTime = new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    timePicker.Focus();
                })
            };

            establishmentLabel.GestureRecognizers.Add(tapEstablishment);
            cuisineLabel.GestureRecognizers.Add(tapCuisine);
            timeLabel.GestureRecognizers.Add(tapTime);
        }
    }
}
