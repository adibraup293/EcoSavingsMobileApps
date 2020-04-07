using EcoSavingsMobileApps.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.Utilities
{
    class RecyclerAuthenticate
    {
        static readonly FirebaseClient firebase =
               new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<List<Recycler>> GetAllRecyclers()
        {
            try
            {
                return (await firebase
                    .Child("Books")
                    .OnceAsync<Recycler>()).Select(item => new Recycler
                    {
                        FullName = item.Object.FullName,
                        EcoLevel = item.Object.EcoLevel,
                        Password = item.Object.Password,
                        TotalPoints = item.Object.TotalPoints,
                        Username = item.Object.Username,
                    }).ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task<Recycler> GetRecycler(Recycler recycler)
        {
            try
            {
                var allRecyclers = await GetAllRecyclers();
                if (allRecyclers != null)
                {
                    return allRecyclers.Where(a => a.Username == recycler.Username).FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA2", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddRecycler(Recycler recycler)
        {
            try
            {
                if (recycler != null)
                {
                    await firebase.Child("Recycler").PostAsync(recycler);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA3", ex.Message, "OK");
            }
        }
    }
}
