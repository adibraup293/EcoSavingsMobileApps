using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class RecyclerLoginViewModel : INotifyPropertyChanged
    {
        public Recycler Recycler { get; set; }

         private bool canSignInRecycler;

         public bool CanSignInRecycler
         {
             get
             {
                 return canSignInRecycler;
             }
             set
             {
                 canSignInRecycler = value;
                 OnPropertyChanged();
             }
         }

         private bool showPassword;
         public bool ShowPassword
         {
             get
             {
                 return !showPassword;
             }
             set
             {
                 showPassword = value;
                 OnPropertyChanged();
             }
         }

         private string loginStatus;
         public string LoginStatus
         {
             get
             {
                 return loginStatus;
             }
             set
             {
                 loginStatus = value;
                 OnPropertyChanged();
             }
         }

         public string Username
         {
             get
             {
                 return Recycler.RecyclerUsername; ;
             }
             set
             {
                 Recycler.RecyclerUsername = value;
                 CanSignInRecycler = CheckUsernameAndPassword();
                 OnPropertyChanged();
             }
         }

         public string Password
         {
             get
             {
                 return Recycler.RecyclerPassword;
             }
             set
             {
                 Recycler.RecyclerPassword = value;
                 CanSignInRecycler = CheckUsernameAndPassword();
                 OnPropertyChanged();
             }
         }

         private bool CheckUsernameAndPassword()
         {
             bool result = !string.IsNullOrWhiteSpace(Recycler.RecyclerUsername) &&
                           !string.IsNullOrWhiteSpace(Recycler.RecyclerPassword);
             return result;
         }

         public ICommand SignInRecycler { get; set; }
         public ICommand OpenRecyclerSignUpView { get; set; }

         public RecyclerLoginViewModel()
         {
             SignInRecycler = new Command(SignInExecute, RecyclerCanSignIn);
             OpenRecyclerSignUpView = new Command(OpenRecyclerSignUpExecute);
             Recycler = new Recycler();
         }

         private bool RecyclerCanSignIn(object arg)
         {
             return CanSignInRecycler;
         }

         private async void SignInExecute(object obj)
         {
             LoginStatus = string.Empty;
             if (CheckUsernameAndPassword())
             {
                 Recycler a = await RecyclerUserAuth.GetRecycler(Recycler);
                 if (a != null)
                 {
                     if (a.RecyclerPassword == Password)
                     {
                         if (Application.Current.Properties.ContainsKey("id"))
                         {
                             Application.Current.Properties["id"] = 1;
                         }
                         else
                         {
                             Application.Current.Properties.Add("id", 1);
                             await Application.Current.SavePropertiesAsync();
                         }
                         App.Username = Username;
                         await Application.Current.MainPage.Navigation.PushAsync(
                             new Views.RecyclerHomeView());
                     }
                     else
                     {
                         Application.Current.Properties["id"] = 0;
                         LoginStatus = "Username or password is wrong!";
                     }
                 }
                 else
                 {
                     LoginStatus = "Username or password not found!";
                 }
             }
             Username = string.Empty;
             Password = string.Empty;
         }

        private void OpenRecyclerSignUpExecute(object obj)
        {
            Username = string.Empty;
            Password = string.Empty;
            Application.Current.MainPage.Navigation.PushAsync(
                new Views.RecyclerSignUpView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
