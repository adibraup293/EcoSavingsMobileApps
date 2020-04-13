using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class UpdateRecyclerProfileViewModel : INotifyPropertyChanged
    {
        public static Recycler Recycler { get; set; }

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

        public string RecyclerPassword
        {
            get
            {
                return Recycler.RecyclerPassword;
            }
            set
            {
                Recycler.RecyclerPassword = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
