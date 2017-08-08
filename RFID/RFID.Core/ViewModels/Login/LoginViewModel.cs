﻿using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RFID.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AuthenticateUserResponse loginResponse;
        private readonly IMvxNavigationService _navigationService;

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string _userName;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(async() =>
                {
                    AuthenticateUserInput userTry = new AuthenticateUserInput()
                    {
                        Username = Username,
                        Password = Password,
                        Device = "Android",
                        Station = "MNL",
                        Version = "0.1"
                    };

                    var loginResponse = await Mvx.Resolve<IRestService>().AuthenticateUser(userTry);

                    await _navigationService.Navigate<MainMenuViewModel>();

                    //loginResponse = new AuthenticateUserResponse();
                    //loginResponse = IsAuthenticated();

                    //if (loginResponse.ReturnCode == "1")
                    //{
                    //    try
                    //    {
                    //        //logger.Trace("SqliteService<UserModel> : LoadUser")
                    //        ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                    //        var user = await userRepo.Load();
                    //        user.IsLoggedIn = true;
                    //        user.Name = loginResponse.Name;
                    //        user.AppAccess = loginResponse.AppAccess;
                    //        await userRepo.InsertUpdate(user);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                    //        //logger.Log(LogLevel.Info,e.ToString);
                    //    }
                    //    await _navigationService.Navigate<MainMenuViewModel>();
                    //}
                    //else
                    //{
                    //    Mvx.Resolve<IUserDialogs>().Alert("Please provide correct Username and Password.", "Invalid Username or Password", "Dismiss");
                    //}
                });
            }
        }

        //public AuthenticateUserResponse IsAuthenticated()
        //{
        //    AuthenticateUserInput userTry = new AuthenticateUserInput()
        //    {
        //        Username = Username,
        //        Password = Password,
        //        DeviceName = "Apple",
        //        Station = "123",
        //        Version = "1"
        //    };
        //    var authResponse = new AuthenticateUserResponse();
        //    try
        //    {
        //        if (Mvx.Resolve<IValidation>().ObjectIsNotNull(userTry))
        //        {
        //            authResponse = Mvx.Resolve<IRestService>().AuthenticateUser(userTry);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
        //        //logger.Log(LogLevel.Info,e.ToString);
        //    }
        //    return authResponse;
        //}
    }
}
