using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand OpenCollectorSignUpView { get; set; }

        public HomeViewModel()
        {
            OpenCollectorSignUpView = new Command(OpenCollectorSignUpExecute);
        }

        private void OpenSignUpExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.SignUpView());
        }

        private void OpenCollectorSignUpExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.RecyclerLoginView());
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
