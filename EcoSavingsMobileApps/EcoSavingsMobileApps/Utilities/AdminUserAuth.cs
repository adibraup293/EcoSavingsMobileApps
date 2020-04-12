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
    class AdminUserAuth
    {
        static readonly FirebaseClient firebase =
            new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<List<User>> GetAllUsers()
        {
            try
            {
                return (await firebase.Child("Users").OnceAsync<User>()).Select(item => new User
                {
                    Username = item.Object.Username,
                    Password = item.Object.Password,
                    FullName = item.Object.FullName,
                    TotalPoints = item.Object.TotalPoints
                }).ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddUser(User User)
        {
            try
            {
                if (User != null)
                {
                    await firebase.Child("User").PostAsync(User);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FA3", ex.Message, "OK");
            }
        }

        public static async Task<User> GetUser(User User)
        {
            try
            {
                var allUsers = await GetAllUsers();
                if (allUsers != null)
                {
                    return allUsers.Where(a => a.Username == User.Username).FirstOrDefault();
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
