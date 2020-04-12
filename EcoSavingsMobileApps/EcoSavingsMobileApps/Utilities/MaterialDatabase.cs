using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.ViewModel;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.Utilities
{
    class MaterialDatabase
    {
        static readonly FirebaseClient firebase =
            new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<ObservableCollection<Material>> GetAllMaterials()
        {
            try
            {
                List<Material> materials = (await firebase
                    .Child("Materials")
                    .OnceAsync<Material>()).Select(item => new Material
                    {
                        MaterialID = item.Object.MaterialID,
                        MaterialName = item.Object.MaterialName,
                        Description = item.Object.Description,
                        Username = item.Object.Username,
                        PointsPerKg = item.Object.PointsPerKg,
                        Key = item.Key
                    }).ToList();

                ObservableCollection<Material> materialsList = new ObservableCollection<Material>();
                foreach (Material material in materials)
                {
                    if (material.Username == App.Username)
                    {
                        materialsList.Add(material);
                    }
                }
                return materialsList;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddMaterial(Material material)
        {
            try
            {
                if (material != null)
                {
                    await firebase.Child("Materials").PostAsync(material);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH2", ex.Message, "OK");
            }
        }

        public static async Task UpdateMaterial(Material material)
        {
            try
            {
                if (material != null)
                {
                    var toUpdateMaterial = (await firebase.Child("Materials")
                        .OnceAsync<Material>()).Where(a  => a.Key == material.Key).FirstOrDefault();
                    await firebase.Child("Materials").Child(toUpdateMaterial.Key).PutAsync(material);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH3", ex.Message, "OK");
            }
        }

        public static async Task DeleteMaterial(Material material)
        {
            try
            {
                if (material != null)
                {
                    var toDeleteMaterial = (await firebase.Child("Materials")
                        .OnceAsync<Material>()).Where(a => a.Key == material.Key).FirstOrDefault();
                    await firebase.Child("Books").Child(toDeleteMaterial.Key).DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH4", ex.Message, "OK");
            }
        }

    }
}
