using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class LogInViewModel : INotifyPropertyChanged
    {
        public User User { get; set; }

        private bool canSign;
        public bool CanSign
        {
            get
            {
                return canSign;
            }
            set
            {
                canSign = value;
                OnPropertyChanged();
            }
        }

        private bool showPassword;
        public bool ShowPassword
        {
            get
            {
                return !showPassword;
            }
            set
            {
                showPassword = value;
                OnPropertyChanged();
            }
        }

        private string loginStatus;
        public string LoginStatus
        {
            get
            {
                return loginStatus;
            }
            set
            {
                loginStatus = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get
            {
                return User.Username; ;
            }
            set
            {
                User.Username = value;
                CanSign = CheckUsernameAndPassword();
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
                CanSign = CheckUsernameAndPassword();
                OnPropertyChanged();
            }
        }

        private bool CheckUsernameAndPassword()
        {
            bool result = !string.IsNullOrWhiteSpace(User.Username) &&
                          !string.IsNullOrWhiteSpace(User.Password);
            return result;
        }

        public ICommand SignIn { get; set; }
        public ICommand OpenSignUpView { get; set; }

        //public LogInViewModel()
        //{
        //    //SignIn = new Command(SignInExecute, CanSignIn);
        //    OpenSignUpView = new Command(OpenSignUpExecute);
        //    User = new User();
        //}

        private bool CanSignIn(object arg)
        {
            return CanSign;
        }
        //private async void SignInExecute(object obj)
        //{
        //    LoginStatus = string.Empty;
        //    if (CheckUsernameAndPassword())
        //    {
        //        //User a = await Authenticate.GetUser(User);
        //        if (a != null)
        //        {
        //            if (a.Password == Password)
        //            {
        //                if (Application.Current.Properties.ContainsKey("id"))
        //                {
        //                    Application.Current.Properties["id"] = 1;
        //                }
        //                else
        //                {
        //                    Application.Current.Properties.Add("id", 1);
        //                    await Application.Current.SavePropertiesAsync();
        //                }
        //                App.Username = Username;
        //                await Application.Current.MainPage.Navigation.PushAsync(
        //                    new Views.HomeView());
        //            }
        //            else
        //            {
        //                Application.Current.Properties["id"] = 0;
        //                LoginStatus = "Username or password is wrong!";
        //            }
        //        }
        //        else
        //        {
        //            LoginStatus = "Username or password not found!";
        //        }
        //    }
        //    Username = string.Empty;
        //    Password = string.Empty;
        //}
        //private void OpenSignUpExecute(object obj)
        //{
        //    Username = string.Empty;
        //    Password = string.Empty;
        //    Application.Current.MainPage.Navigation.PushAsync(
        //        new Views.SignUpView());
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
