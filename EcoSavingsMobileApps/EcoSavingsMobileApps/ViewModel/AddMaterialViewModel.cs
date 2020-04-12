using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class AddMaterialViewModel : INotifyPropertyChanged
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

        public int MaterialIDName = 1;
        public string MaterialID
        {
            get
            {
                return Material.MaterialID;
            }
            set
            {
                Material.MaterialID = "M"+MaterialIDName;
                MaterialIDName++;
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

        public ICommand AddMaterial { get; private set; }
        public AddMaterialViewModel()
        {
            Material = new Material();
            Material.Username = App.Username;
            AddMaterial = new Command(AddExecute);
        }
        private async void AddExecute()
        {
            await MaterialDatabase.AddMaterial(Material);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
