using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
	class SignUpViewModel
	{
		private bool canSignUp;

		public bool CanSignUp
		{
			get { return canSignUp; }
			set
			{
				canSignUp = value;
				OnPropertyChanged();
			}
		}


		public User User { get; set; }

		public string Username
		{
			get
			{
				return User.Username;
			}
			set
			{
				User.Username = value;
				CanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
							 !string.IsNullOrWhiteSpace(Password) &&
							 !string.IsNullOrWhiteSpace(ConfirmPassword));
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get
			{
				return User.Password;
			}
			set
			{
				User.Password = value;
				CanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
							 !string.IsNullOrWhiteSpace(Password) &&
							 !string.IsNullOrWhiteSpace(ConfirmPassword));
				OnPropertyChanged();
			}
		}

		private string confirmPassword;
		public string ConfirmPassword
		{
			get
			{
				return confirmPassword;
			}
			set
			{
				confirmPassword = value;
				CanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
							 !string.IsNullOrWhiteSpace(Password) &&
							 !string.IsNullOrWhiteSpace(ConfirmPassword));
				OnPropertyChanged();
			}
		}

		public ICommand SignUp { get; set; }

		public SignUpViewModel()
		{
			SignUp = new Command(SignUpExecute, CanSignUpM);
			User = new User();
		}

		private bool CanSignUpM(object arg)
		{
			return CanSignUp;
		}

		private async void SignUpExecute(object obj)
		{
			if (CheckPassword())
			{
				if (!string.IsNullOrWhiteSpace(Username) &&
					!string.IsNullOrWhiteSpace(Password))
				{
					await Authenticate.AddUser(User);
					await Application.Current.MainPage.Navigation.PopAsync();
				}
			}
		}

		private bool CheckPassword()
		{
			if (ConfirmPassword == Password)
			{
				return true;
			}
			return false;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
