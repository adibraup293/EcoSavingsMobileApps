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
    class FirebaseHelper
    {
        static readonly FirebaseClient firebase = new FirebaseClient("https://mobileassignment-1ca2e.firebaseio.com/");

        public static async Task<ObservableCollection<User>> GetAllUsers()
        {
            try
            {
                List<User> users = (await firebase
                    .Child("Users")
                    .OnceAsync<User>()).Select(item => new User
                    {
                        Username = item.Object.Username,
                        Password = item.Object.Password,
                        FullName = item.Object.FullName,
                        TotalPoints = item.Object.TotalPoints,
                        UserType = item.Object.UserType
                    }).ToList();

                ObservableCollection<User> userList = new ObservableCollection<User>();
                foreach (User user in users)
                {
                    if (user.Username == App.Username)
                    {
                        userList.Add(user);
                    }
                }
                return userList;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH1", ex.Message, "OK");
                return null;
            }
        }

        public static async Task AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    await firebase.Child("Users").PostAsync(user);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Firebase Exception FH2", ex.Message, "OK");
            }
        }


    }
}
