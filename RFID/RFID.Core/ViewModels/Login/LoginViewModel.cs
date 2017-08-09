using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        //Working
        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(async () =>
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

                    switch (loginResponse.StatusCode)
                    {
                        case "0":
                            try
                            {
                                //logger.Trace("SqliteService<UserModel> : LoadUser")
                                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                                var user = await userRepo.Load();
                                user.IsLoggedIn = true;
                                user.Name = loginResponse.Name;
                                //user.AppAccess = loginResponse.Application;
                                user.AppAccess = "Pier,Arrival,Departure,Claim,BSO";
                                await userRepo.InsertUpdate(user);
                            }
                            catch (Exception)
                            {
                                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                                //logger.Log(LogLevel.Info,e.ToString);
                            }
                            await _navigationService.Navigate<MainMenuViewModel>();
                            break;
                        default:
                            Mvx.Resolve<IUserDialogs>().Alert("Please provide correct Username and Password.", "Invalid Username or Password", "Dismiss");
                            break;
                    }
                });
            }
        }


        ///implement this on all view model. This property will be used to avoid multiple process at the same time
        ///possibly add a wait screet when IsBusy is set to true
        private bool IsBusy { get; set; }
        public ICommand LoginCommanNew
        {
            get
            {

                return new MvxCommand(async () => await AuthenticateUser());
            }
        }

        /// <summary>
        /// Method to process user login
        /// </summary>
        private async Task AuthenticateUser()
        {
            {

                if (IsBusy) { return; }
                ///set IsBusy property to true
                IsBusy = true;
                try
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("username", Username);
                    parameters.Add("password", Password);
                    var restService = Mvx.Resolve<IRestService>();
                    restService.WebMethod = "AuthenticateUser";
                    restService.Parameters = parameters;

                    string response = await restService.Consume();
                    AuthenticateUserResponse authResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(response);

                    switch (authResponse.StatusCode)
                    {
                        case "0":
                            await _navigationService.Navigate<MainMenuViewModel>();
                            break;
                        default:
                            Mvx.Resolve<IUserDialogs>().Alert("Please provide correct Username and Password.", "Invalid Username or Password", "Dismiss");
                            break;
                    }
                    //Junvic used success boolean instead of returnCode
                    //if (authResponse.Success == true)
                    //{
                    //    await _navigationService.Navigate<MainMenuViewModel>();
                    //}
                    //else
                    //{
                    //    Mvx.Resolve<IUserDialogs>().Alert("Please provide correct Username and Password.", "Invalid Username or Password", "Dismiss");
                    //}
                    //JObject jResponse = JObject.Parse(response);

                    ///process response using the return code. Coordinate with junvic on possible error codes
                
                    //switch (jResponse.GetValue("returnCode").ToString())
                    //{
                    //    case "1":
                    //        //successful
                    //        await _navigationService.Navigate<MainMenuViewModel>();
                    //        break;
                    //    case "2":
                    //        //process error response. Use the message from the JResponse
                    //        break;
                    //    default:
                    //        //display generic error
                    //        break;

                    //}
                }
                catch (JsonReaderException e)
                {
                }
                catch (WebException e)
                {
                    ///process web requests exception
                }
                catch (Exception e)
                {
                    var x = e.Message;
                    ///generic exception handler
                }
                finally
                {

                    IsBusy = false;
                }

            }

        }
    }
}
