using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class RecyclerSignUpViewModel : INotifyPropertyChanged
    {

        private bool recyclerCanSignUp;

        public bool RecyclerCanSignUp
        {
            get { return recyclerCanSignUp; }
            set
            {
                recyclerCanSignUp = value;
                OnPropertyChanged();
            }
        }

        public static Recycler Recycler { get; set; }

        public string Username
        {
            get
            {
                return Recycler.Username;
            }
            set
            {
                Recycler.Username = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return Recycler.Password;
            }
            set
            {
                Recycler.Password = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
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
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        public ICommand CanSignUpRecycler { get; set; }

        public RecyclerSignUpViewModel()
        {
            Recycler = new Recycler();
            CanSignUpRecycler = new Command(RecyclerSignUpExecute, CanRecyclerSignUp);
        }

        private async void RecyclerSignUpExecute(object obj)
        {
            if (CheckPassword())
            {
                if (!string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    !string.IsNullOrWhiteSpace(FullName))
                {
                    await RecyclerAuthenticate.AddRecycler(Recycler);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private bool CanRecyclerSignUp(object arg)
        {
            return RecyclerCanSignUp;
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
