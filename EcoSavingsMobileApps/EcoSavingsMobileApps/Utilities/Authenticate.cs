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
        class Authenticate
        {
            static readonly FirebaseClient firebase =
               new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

            public static async Task<List<User>> GetAllUsers()
            {
                try
                {
                    return (await firebase
                        .Child("Users")
                        .OnceAsync<User>()).Select(item => new User
                        {
                            Password = item.Object.Password,
                            Username = item.Object.Username
                        }).ToList();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Firebase Exception FA1", ex.Message, "OK");
                    return null;
                }
            }

            public static async Task<User> GetUser(User user)
            {
                try
                {
                    var allUsers = await GetAllUsers();
                    if (allUsers != null)
                    {
                        return allUsers.Where(a => a.Username == user.Username).FirstOrDefault();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Firebase Exception FA2", ex.Message, "OK");
                    return null;
                }
            }

            public static async Task AddUser(User user)
            {
                try
                {
                    if (user != null)
                    {
                        await firebase
                            .Child("Users")
                            .PostAsync(user);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Firebase Exception FA3", ex.Message, "OK");
                }
            }
        }
}
