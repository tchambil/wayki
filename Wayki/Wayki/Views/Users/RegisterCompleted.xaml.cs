﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wayki.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterCompleted : ContentPage
    {
        public bool Cargado = false;
        public RegisterCompleted ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;

            if (true)
            {
                IndicadorDeCarga.IsVisible = false;
                Grilla.IsVisible = true;
                return;
            }
        }
        public async void IrAlInicio(object sender, EventArgs e)
        {
          //  App.Current.MainPage = new Views.Principal.MainPage(new EmergencyAppService(), new EstablishmentAppService());
        }
    }
}