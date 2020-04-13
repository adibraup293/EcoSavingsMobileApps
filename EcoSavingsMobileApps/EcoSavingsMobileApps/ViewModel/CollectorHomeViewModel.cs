using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class CollectorHomeViewModel : INotifyPropertyChanged
    {

        public ICommand OpenRecordMaterialsView { get; set; }
        public ICommand OpenSubmissionHistoryView { get; set; }
        public ICommand OpenUpdateUserView { get; set; }
        public ICommand OpenHomeView { get; set; }

        public CollectorHomeViewModel()
        {
            OpenRecordMaterialsView = new Command(OpenRecordMaterialExecute);
            OpenSubmissionHistoryView = new Command(OpenSubmissionHistoryExecute);
            OpenUpdateUserView = new Command(OpenUpdateUserExecute);
            OpenHomeView = new Command(OpenHomeViewExecute);
        }

        private void OpenRecordMaterialExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.RecordMaterialView());
        }

        private void OpenSubmissionHistoryExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.SubmissionHistoryView());
        }

        private void OpenUpdateUserExecute(object obj)
        {
            UpdateUserViewModel.Collector = (Collector)obj;
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.UpdateUserView());
        }

        private void OpenHomeViewExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.HomeView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
