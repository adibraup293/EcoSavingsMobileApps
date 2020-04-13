using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class AdminHomeViewModel : INotifyPropertyChanged
    {
		private object selectedItem;

		public object SelectedItem
		{
			get
			{
				return selectedItem;
			}
			set
			{
				selectedItem = value;
				if (selectedItem == null)
				{
					OnPropertyChanged();
				}
				ViewMaterialDetail.Execute(selectedItem);
				selectedItem = null;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Material> MaterialsList { get; set; }

		public ICommand AddNewMaterial { get; set; }
		public ICommand ViewMaterialDetail { get; set; }

		public AdminHomeViewModel()
		{
			AddNewMaterial = new Command(AddNewMaterialExecute);
			ViewMaterialDetail = new Command(ViewMaterialDetailExecute);
			MaterialsList = new ObservableCollection<Material>();
			GetAllMaterials();
		}

		private async void AddNewMaterialExecute(object obj)
		{
			await Application.Current.MainPage.Navigation.PushAsync(new Views.AddMaterialView());
		}

		private async void ViewMaterialDetailExecute(object obj)
		{
			MaterialDetailViewModel.Material = (Material)obj;
			await Application.Current.MainPage.Navigation.PushAsync(
				new Views.MaterialDetailView());
		}

		private async void GetAllMaterials()
		{
			MaterialsList = await MaterialDatabase.GetAllMaterials();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
