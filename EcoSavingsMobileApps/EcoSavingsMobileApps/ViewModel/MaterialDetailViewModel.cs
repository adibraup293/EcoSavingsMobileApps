using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class MaterialDetailViewModel : INotifyPropertyChanged
    {
        public static Material Material { get; set; }

        public string MaterialName
        {
            get
            {
                return Material.MaterialName;
            }
            set
            {
                Material.MaterialName = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return Material.Description;
            }
            set
            {
                Material.Description = value;
                OnPropertyChanged();
            }
        }

        public int PointsPerKG
        {
            get
            {
                return Material.PointsPerKg;
            }
            set
            {
                Material.PointsPerKg = value;
                OnPropertyChanged();
            }
        }

        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }

        public MaterialDetailViewModel()
        {
            Update = new Command(UpdateExecute);
            Delete = new Command(DeleteExecute);
        }

        private async void UpdateExecute()
        {
            await MaterialDatabase.UpdateMaterial(Material);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void DeleteExecute()
        {
            await MaterialDatabase.DeleteMaterial(Material);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
