using System;
using System.Collections.Generic;
using System.Text;
using EcoSavingsMobileApps.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.Utilities
{
    class CollectorUserAuth
    {
        static readonly FirebaseClient firebase =
            new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<List<Collector>> GetAllCollectors()
        {
            try
            {
                return (await firebase.Child("Collectors").OnceAsync<Collector>()).Select(item => new Collector
                {
                    CollectorUsername = item.Object.CollectorUsername,
                    CollectorPassword = item.Object.CollectorPassword,
                    CollectorFullName = item.Object.CollectorFullName,
                    TotalPoints = item.Object.TotalPoints,
                    CollectorAddress = item.Object.CollectorAddress
                }).ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddCollector(Collector Collector)
        {
            try
            {
                if (Collector != null)
                {
                    await firebase.Child("Collector").PostAsync(Collector);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA3", ex.Message, "OK");
            }
        }

        public static async Task<Collector> GetCollector(Collector Collector)
        {
            try
            {
                var allCollectors = await GetAllCollectors();
                if (allCollectors != null)
                {
                    return allCollectors.Where(a => a.CollectorUsername == Collector.CollectorUsername).FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA2", ex.Message, "OK");
                return null;
            }
        }
    }

    
}
