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

        private bool IsBusy { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new MvxCommand(async () => await AuthenticateUser());
            }
        }

        private async Task AuthenticateUser()
        {
            {
                if (IsBusy) { return; }
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
                            ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                            var user = await userRepo.Load();
                            user.IsLoggedIn = true;
                            user.Name = authResponse.Name;
                            string appAccess = "";
                            foreach (var item in authResponse.Applications)
                            {
                                appAccess += item + ",";
                            }
                            user.AppAccess = appAccess;
                            await userRepo.InsertUpdate(user);
                            break;
                        default:
                            Mvx.Resolve<IUserDialogs>().Alert("Please provide correct Username and Password.", "Invalid Username or Password", "Dismiss");
                            break;
                    }
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
