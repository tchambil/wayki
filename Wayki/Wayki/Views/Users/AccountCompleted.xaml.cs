using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayki.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
 
namespace Wayki.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountCompleted : ContentPage
    {
        IUserAppService _userAppService;
        public bool Cargado = false;
        public AccountCompleted (IUserAppService userAppService)
        {
            _userAppService = userAppService;
            InitializeComponent();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;

            
      
        }
        public async void IrAlInicio(object sender, EventArgs e)
        {
         //   App.Current.MainPage = new Views.Principal.MainPage(new EmergencyAppService(), new EstablishmentAppService());
        }
    }
}