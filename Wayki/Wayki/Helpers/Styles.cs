using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace Wayki.Helpers
{
   public class Styles
    {
        public static string FuenteLight
        {
            get
            {
                return Device.OnPlatform("Lato-Light", "Lato-Light.ttf#Lato-Light", "");
            }
        }
        public static string FuenteRegular
        {
            get
            {
                return Device.OnPlatform("Lato-Regular", "Lato-Regular.ttf#Lato-Regular", "");
            }
        }
        public static string FuenteBold
        {
            get
            {
                return Device.OnPlatform("Lato-Bold", "Lato-Bold.ttf#Lato-Bold", "");
            }

        }
        public static Thickness MargenInputs
        {
            get
            {
                return Device.OnPlatform(new Thickness(0, 15, 0, 0), new Thickness(0, 0, 0, 0), new Thickness(0, 0, 0, 0));
            }
        }
    }
}
