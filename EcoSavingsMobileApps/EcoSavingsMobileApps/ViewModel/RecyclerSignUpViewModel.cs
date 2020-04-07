﻿using EcoSavingsMobileApps.Models;
using EcoSavingsMobileApps.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcoSavingsMobileApps.ViewModel
{
    class RecyclerSignUpViewModel : INotifyPropertyChanged
    {

        private bool recyclerCanSignUp;

        public bool RecyclerCanSignUp
        {
            get { return recyclerCanSignUp; }
            set
            {
                recyclerCanSignUp = value;
                OnPropertyChanged();
            }
        }

        public Recycler User { get; set; }

        public string Username
        {
            get
            {
                return User.Username;
            }
            set
            {
                User.Username = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return User.Password;
            }
            set
            {
                User.Password = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                RecyclerCanSignUp = (!string.IsNullOrWhiteSpace(Username) &&
                             !string.IsNullOrWhiteSpace(Password) &&
                             !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                             !string.IsNullOrWhiteSpace(FullName));
                OnPropertyChanged();
            }
        }

        public ICommand CanSignUpRecycler { get; set; }

        public RecyclerSignUpViewModel()
        {
            CanSignUpRecycler = new Command(SignUpExecute, CanSignUp);
            User = new Recycler();
        }

        private async void SignUpExecute(object obj)
        {
            if (CheckPassword())
            {
                if (!string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    !string.IsNullOrWhiteSpace(FullName))
                {
                    await Authenticate.AddUser(User);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private bool CanSignUp(object arg)
        {
            return RecyclerCanSignUp;
        }

        private bool CheckPassword()
        {
            if (ConfirmPassword == Password)
            {
                return true;
            }
            return false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
