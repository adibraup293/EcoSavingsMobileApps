using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class CollectorSignUpViewModel : INotifyPropertyChanged
    {
        private bool collectorCanSignUp;

        public bool CollectorCanSignUp
        {
            get
            {
                return collectorCanSignUp;
            }
            set
            {
                collectorCanSignUp = value;
                OnPropertyChanged();
            }
        }

        public static Collector Collector { get; set; }

        public string CollectorUsername
        {
            get
            {
                return Collector.CollectorUsername;
            }
            set
            {
                Collector.CollectorUsername = value;
                CollectorCanSignUp = (!string.IsNullOrWhiteSpace(CollectorUsername) &&
                    !string.IsNullOrWhiteSpace(CollectorPassword) &&
                    !string.IsNullOrWhiteSpace(CollectorConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string CollectorPassword
        {
            get
            {
                return Collector.CollectorPassword;
            }
            set
            {
                Collector.CollectorPassword = value;
                CollectorCanSignUp = (!string.IsNullOrWhiteSpace(CollectorUsername) &&
                    !string.IsNullOrWhiteSpace(CollectorPassword) &&
                    !string.IsNullOrWhiteSpace(CollectorConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string collectorConfirmPassword;
        public string CollectorConfirmPassword
        {
            get
            {
                return CollectorConfirmPassword;
            }
            set
            {
                CollectorConfirmPassword = value;
                CollectorCanSignUp = (!string.IsNullOrWhiteSpace(CollectorUsername) &&
                    !string.IsNullOrWhiteSpace(CollectorPassword) &&
                    !string.IsNullOrWhiteSpace(CollectorConfirmPassword));
                OnPropertyChanged();
            }
        }

        public string CollectorFullName
        {
            get
            {
                return Collector.CollectorFullName;
            }
            set
            {
                Collector.CollectorFullName = value;
                OnPropertyChanged();
            }
        }

        public string CollectorAddress
        {
            get
            {
                return Collector.CollectorAddress;
            }
            set
            {
                Collector.CollectorAddress = value;
            }
        }

        public ICommand SignUpCollector { get; set; }

        public CollectorSignUpViewModel()
        {
            SignUpCollector = new Command(CollectorSignUpExecute, CanSignUpC);
            Collector = new Collector();
        }



        private bool CanSignUpC(object arg)
        {
            return CollectorCanSignUp;
        }

        private async void CollectorSignUpExecute(object obj)
        {
            if (CheckCollectorPassword())
            {
                if (!string.IsNullOrWhiteSpace(CollectorUsername) &&
                    !string.IsNullOrWhiteSpace(CollectorPassword) &&
                    !string.IsNullOrWhiteSpace(CollectorFullName))
                {
                    await CollectorUserAuth.AddCollector(Collector);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private bool CheckCollectorPassword()
        {
            if (CollectorConfirmPassword == CollectorPassword)
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
