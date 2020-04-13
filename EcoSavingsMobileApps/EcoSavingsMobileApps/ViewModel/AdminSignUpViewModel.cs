using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class AdminSignUpViewModel : INotifyPropertyChanged
    {
        private bool userCanSignUp;

        public bool UserCanSignUp
        {
            get
            {
                return userCanSignUp;
            }
            set
            {
                userCanSignUp = value;
                OnPropertyChanged();
            }
        }

        public static User User { get; set; }

        public string Username
        {
            get
            {
                return User.Username;
            }
            set
            {
                User.Username = value;
                UserCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
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
                UserCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    !string.IsNullOrWhiteSpace(ConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string userConfirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return userConfirmPassword;
            }
            set
            {
                userConfirmPassword = value;
                UserCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    !string.IsNullOrWhiteSpace(ConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get
            {
                return User.FullName;
            }
            set
            {
                User.FullName = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignUpUser { get; set; }
        public ICommand Back { get; set; }

        private void BackExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.HomeView());
        }

        public AdminSignUpViewModel()
        {
            SignUpUser = new Command(UserSignUpExecute, CanSignUpU);
            Back = new Command(BackExecute);
            User = new User();
        }



        private bool CanSignUpU(object arg)
        {
            return UserCanSignUp;
        }

        private async void UserSignUpExecute(object obj)
        {
            if (CheckUserPassword())
            {
                if (!string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    !string.IsNullOrWhiteSpace(FullName))
                {
                    await AdminUserAuth.AddUser(User);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private bool CheckUserPassword()
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
