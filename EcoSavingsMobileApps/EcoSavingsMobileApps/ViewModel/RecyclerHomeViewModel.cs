using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class RecyclerHomeViewModel : INotifyPropertyChanged
    {
        public ICommand OpenUpdateRecyclerProfileView { get; set; }
        public ICommand OpenMakeAppointmentView { get; set; }
        public ICommand OpenSubmissionHistoryView { get; set; }
        public ICommand Back { get; set; }

        public RecyclerHomeViewModel()
        {
            OpenUpdateRecyclerProfileView = new Command(OpenRecyclerUpdateExecute);
            OpenMakeAppointmentView = new Command(OpenMakeAppointmentExecute);
            OpenSubmissionHistoryView = new Command(OpenSubmissionHistoryExecute);
            Back = new Command(BackExecute);
        }

        private void OpenRecyclerUpdateExecute(object obj)
        {
            UpdateRecyclerProfileViewModel.Recycler = (Recycler)obj;
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.UpdateRecyclerProfileView());
        }

        private void OpenMakeAppointmentExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.MakeAppointmentView());
        }

        private void OpenSubmissionHistoryExecute(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.SubmissionHistoryView());
        }

        private void BackExecute(object obj)
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
