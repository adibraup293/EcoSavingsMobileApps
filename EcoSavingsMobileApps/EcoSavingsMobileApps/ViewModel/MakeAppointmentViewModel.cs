using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
namespace EcoSavingsMobileApps.ViewModel
{
    class MakeAppointmentViewModel :INotifyPropertyChanged
    {
        public ICommand Back { get; set; }

        public MakeAppointmentViewModel()
        {
            Back = new Command(BackExecute);
        }

        private void BackExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.RecyclerHomeView());
        }
            public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
