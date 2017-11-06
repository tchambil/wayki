using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wayki.Services;
using Xamarin.Forms;

namespace Wayki
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Wayki.Views.Users.Account(new UserAppService());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
