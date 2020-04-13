using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class CollectorLoginViewModel : INotifyPropertyChanged
    {
        public Collector Collector { get; set; }

        private bool canSignInCollector;

        public bool CanSignInCollector
        {
            get
            {
                return canSignInCollector;
            }
            set
            {
                canSignInCollector = value;
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
                return Collector.CollectorUsername; ;
            }
            set
            {
                Collector.CollectorUsername = value;
                CanSignInCollector = CheckUsernameAndPassword();
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return Collector.CollectorPassword;
            }
            set
            {
                Collector.CollectorPassword = value;
                CanSignInCollector = CheckUsernameAndPassword();
                OnPropertyChanged();
            }
        }

        private bool CheckUsernameAndPassword()
        {
            bool result = !string.IsNullOrWhiteSpace(Collector.CollectorUsername) &&
                          !string.IsNullOrWhiteSpace(Collector.CollectorPassword);
            return result;
        }

        public ICommand SignInCollector { get; set; }
        public ICommand OpenCollectorSignUpView { get; set; }
        public ICommand Back { get; set; }

        private void BackExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.HomeView());
        }

        public CollectorLoginViewModel()
        {
            SignInCollector = new Command(SignInExecute, CollectorCanSignIn);
            OpenCollectorSignUpView = new Command(OpenCollectorSignUpExecute);
            Back = new Command(BackExecute);
            Collector = new Collector();
        }

        private bool CollectorCanSignIn(object arg)
        {
            return CanSignInCollector;
        }

        private async void SignInExecute(object obj)
        {
            LoginStatus = string.Empty;
            if (CheckUsernameAndPassword())
            {
                Collector a = await CollectorUserAuth.GetCollector(Collector);
                if (a != null)
                {
                    if (a.CollectorPassword == Password)
                    {
                        if (Application.Current.Properties.ContainsKey("id"))
                        {
                            Application.Current.Properties["id"] = 1;
                        }
                        else
                        {
                            Application.Current.Properties.Add("id", 1);
                            await Application.Current.SavePropertiesAsync();
                        }
                        App.Username = Username;
                        await Application.Current.MainPage.Navigation.PushAsync(
                            new Views.CollectorHomeView());
                    }
                    else
                    {
                        Application.Current.Properties["id"] = 0;
                        LoginStatus = "Username or password is wrong!";
                    }
                }
                else
                {
                    LoginStatus = "Username or password not found!";
                }
            }
            Username = string.Empty;
            Password = string.Empty;
        }

        private void OpenCollectorSignUpExecute(object obj)
        {
            Username = string.Empty;
            Password = string.Empty;
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.CollectorSignUpView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
