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

        public RecyclerHomeViewModel()
        {
            OpenUpdateRecyclerProfileView = new Command(OpenRecyclerUpdateExecute);
        }

        private void OpenRecyclerUpdateExecute(object obj)
        {
            UpdateRecyclerProfileViewModel.Recycler = (Recycler)obj;
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.UpdateRecyclerProfileView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
