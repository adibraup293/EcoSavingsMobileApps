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
        private void OpenSignUpExecute(object obj)
        {
            
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.SignUpView());
        }
    }
}
