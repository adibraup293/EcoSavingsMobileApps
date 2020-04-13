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
            get
            {
                return recyclerCanSignUp;
            }
            set
            {
                recyclerCanSignUp = value;
                OnPropertyChanged();
            }
        }

        public static Recycler Recycler { get; set; }

        public string RecyclerUsername
        {
            get
            {
                return Recycler.RecyclerUsername;
            }
            set
            {
                Recycler.RecyclerUsername = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(RecyclerUsername) &&
                    !string.IsNullOrWhiteSpace(RecyclerPassword) &&
                    !string.IsNullOrWhiteSpace(RecyclerConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string RecyclerPassword
        {
            get
            {
                return Recycler.RecyclerPassword;
            }
            set
            {
                Recycler.RecyclerPassword = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(RecyclerUsername) &&
                    !string.IsNullOrWhiteSpace(RecyclerPassword) &&
                    !string.IsNullOrWhiteSpace(RecyclerConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string recyclerConfirmPassword;
        public string RecyclerConfirmPassword
        {
            get
            {
                return recyclerConfirmPassword;
            }
            set
            {
                recyclerConfirmPassword = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(RecyclerUsername) &&
                    !string.IsNullOrWhiteSpace(RecyclerPassword) &&
                    !string.IsNullOrWhiteSpace(RecyclerConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string RecyclerFullName
        {
            get
            {
                return Recycler.RecyclerFullName;
            }
            set
            {
                Recycler.RecyclerFullName = value;
                OnPropertyChanged();
            }
        }

        public string EcoLevel
        {
            get 
            { 
                return Recycler.RecyclerEcoLevel; 
            }
            set
            {
                Recycler.RecyclerEcoLevel = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignUpRecycler { get; set; }
        public ICommand Back { get; set; }

        private void BackExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.HomeView());
        }

        public RecyclerSignUpViewModel()
        {
            SignUpRecycler = new Command(RecyclerSignUpExecute, CanSignUpR);
            Back = new Command(BackExecute);
            Recycler = new Recycler();
        }

        

        private bool CanSignUpR(object arg)
        {
            return RecyclerCanSignUp;
        }

        private async void RecyclerSignUpExecute(object obj)
        {
            if (CheckRecyclerPassword())
            {
                if (!string.IsNullOrWhiteSpace(RecyclerUsername) &&
                    !string.IsNullOrWhiteSpace(RecyclerPassword) &&
                    !string.IsNullOrWhiteSpace(RecyclerFullName))
                {
                    await RecyclerUserAuth.AddRecycler(Recycler);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private bool CheckRecyclerPassword()
        {
            if (RecyclerConfirmPassword == RecyclerPassword)
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
