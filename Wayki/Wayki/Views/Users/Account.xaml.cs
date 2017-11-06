using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wayki.Models;
using Wayki.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wayki.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Account : ContentPage
    {
        IUserAppService _userAppService;
        public Account ()
		{
			InitializeComponent ();
		}
        async void OnRegister(object sender, EventArgs e)
        {

            App.Current.MainPage = new Register();
        }
        async void OnLogin(object sender, EventArgs e)
        {

            var _LoginModel = (LoginInput)BindingContext;
            if(_LoginModel==null)
            {
                await DisplayAlert("Error", "Debe ingresar sus datos", "Aceptar");          
                return;
            }
            if (string.IsNullOrEmpty(_LoginModel.UsernameOrEmailAddress))
            {
                await DisplayAlert("Error", "Debe ingresar usuario o email", "Aceptar");
                UsernameOrEmailAddressEntry.Focus();
                return;
            }


            if (string.IsNullOrEmpty(_LoginModel.Password))
            {
                await DisplayAlert("Error", "Debe ingresar la contraseña", "Aceptar");
                UsernameOrEmailAddressEntry.Focus();
                return;
            }
            UserAppService.UserLoing = new LoginInput
            {
                UsernameOrEmailAddress = _LoginModel.UsernameOrEmailAddress,
                Password = _LoginModel.Password
            };

            App.Current.MainPage = new AccountCompleted(new UserAppService());
             
        }
        void Entry_EmailTextChanged(object sender, TextChangedEventArgs e)
        {
            if (UsernameOrEmailAddressEntry.Text.Trim().Length > 50)
            {
                return;
            }
            var EmailRegex = @"^[\p{L}\p{N}\.@_-\-_]+$";
            UsernameOrEmailAddressEntry.Text = e.NewTextValue.ToUpper();
            string _text = UsernameOrEmailAddressEntry.Text;
            bool EsValido = (Regex.IsMatch(e.NewTextValue, EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!EsValido)
            {
                if (_text.Length > 1)
                {
                    _text = _text.Remove(_text.Length - 1);
                    UsernameOrEmailAddressEntry.Text = _text.ToUpper();
                }
                else
                {
                    UsernameOrEmailAddressEntry.Text = "";
                }

            }


        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.IsPassword = true;
        }
    }
}