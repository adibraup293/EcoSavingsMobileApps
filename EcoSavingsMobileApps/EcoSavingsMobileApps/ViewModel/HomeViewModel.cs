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
        public ICommand OpenCollectorLoginView { get; set; }
        public ICommand OpenRecyclerLoginView { get; set; }
        public ICommand OpenLoginView { get; set; }

        public HomeViewModel()
        {
            OpenCollectorLoginView = new Command(OpenCollectorLoginExecute);
            OpenRecyclerLoginView = new Command(OpenRecyclerLoginExecute);
            OpenLoginView = new Command(OpenLoginViewExecute);
        }

        private void OpenCollectorLoginExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.CollectorLoginView()); 
        }

        private void OpenRecyclerLoginExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.RecyclerLoginView());
        }

        private void OpenLoginViewExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.LogInView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
        
    }
}
