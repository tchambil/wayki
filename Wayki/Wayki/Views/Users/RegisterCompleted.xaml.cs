using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayki.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wayki.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterCompleted : ContentPage
    {
        IUserAppService _userAppService;
        public bool Cargado = false;
        public RegisterCompleted(IUserAppService userAppService)
        {
            _userAppService = userAppService;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            var result = await _userAppService.AddOrUpdate(UserAppService.UserCurrent);
            if (result == null)
            {
                await DisplayAlert("Error", "No hay conexion con el servidor, intente más tarde", "Aceptar");
                return;
            }
            else
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