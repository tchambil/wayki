using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayki.Models;
using Wayki.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wayki.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
            BindingContext = new UserInput();
            
        }
        async void OnRegister(object sender, EventArgs e)
        {

            var valido = NombresValidar.Validar(Nombres.Text);
            valido = valido & ApellidosValidar.Validar(Apellidos.Text);
            valido = valido & EmailValidar.Validar(Email.Text);
            valido = valido & DNIValidar.Validar(DNI.Text);
            valido = valido & TelefonoValidar.Validar(Telefono.Text);
            //   valido = valido & PasswordValidar.Validar(Password.Text);
            if (!valido)
            {
                await DisplayAlert("Aviso", "Por favor llene los campos según se indican.", "Aceptar");
                return;
            }
            else
            {
                if ((DNI.Text.Length < 8 | DNI.Text.Length > 8))
                {
                    await DisplayAlert("Aviso", "Número de documento debe ser 8 dígitos.", "Aceptar");
                    return;
                }
                UserAppService.UserCurrent = new UserInput
                {
                    Name = Nombres.Text,
                    Surname = Apellidos.Text,
                    Dni = DNI.Text,
                    EmailAddress = Email.Text,
                    Password = Password.Text,
                    PasswordRepeat = Password.Text,
                    UserName = Email.Text,
                    PhoneNumber = Telefono.Text
                };
                App.Current.MainPage = new RegisterCompleted(new UserAppService());
            }
        }
        async void OnBack(object sender, EventArgs e)
        {
          //  App.Current.MainPage = new Views.Principal.MainPage(new EmergencyAppService(), new EstablishmentAppService());
        }
    }
}