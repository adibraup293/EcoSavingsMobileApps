using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
namespace EcoSavingsMobileApps.ViewModel
{
    class UpdateUserViewModel : INotifyPropertyChanged
    {
        public static Collector Collector { get; set; }

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

        public string CollectorPassword
        {
            get
            {
                return Collector.CollectorPassword;
            }
            set
            {
                Collector.CollectorPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateUser { get; set; }

        public UpdateUserViewModel()
        {
            UpdateUser = new Command(UpdateExecute);
        }

        private async void UpdateExecute()
        {
            await CollectorUserAuth.UpdateCollector(Collector);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
