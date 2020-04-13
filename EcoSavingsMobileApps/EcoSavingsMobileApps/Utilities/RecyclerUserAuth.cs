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
    class RecyclerUserAuth
    {
        static readonly FirebaseClient firebase =
            new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<List<Recycler>> GetAllRecyclers()
        {
            try
            {
                return (await firebase.Child("Recyclers").OnceAsync<Recycler>()).Select(item => new Recycler
                {
                    RecyclerUsername = item.Object.RecyclerUsername,
                    RecyclerPassword = item.Object.RecyclerPassword,
                    RecyclerFullName = item.Object.RecyclerFullName,
                    RecyclerTotalPoints = item.Object.RecyclerTotalPoints,
                    Key = item.Key,
                    RecyclerEcoLevel = item.Object.RecyclerEcoLevel
                }).ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddRecycler(Recycler recycler)
        {
            try
            {
                if(recycler != null)
                {
                    await firebase.Child("Recycler").PostAsync(recycler);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA3", ex.Message, "OK");
            }
        }

        public static async Task<Recycler> GetRecycler(Recycler recycler)
        {
            try
            {
                var allRecyclers = await GetAllRecyclers();
                if (allRecyclers != null)
                {
                    return allRecyclers.Where(a => a.RecyclerUsername == recycler.RecyclerUsername).FirstOrDefault();
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
