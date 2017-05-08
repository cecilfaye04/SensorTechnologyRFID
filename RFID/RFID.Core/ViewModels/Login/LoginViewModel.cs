using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Entities;
using RFID.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RFID.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AuthenticateUserResponse loginResponse;

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
                    
                    loginResponse = new AuthenticateUserResponse();
                    loginResponse = IsAuthenticated();

                    if (loginResponse.ReturnCode == "1")
                    {
                        var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
                        user.IsLoggedIn = true;
                        user.Name = loginResponse.Name;
                        await Mvx.Resolve<ISqliteService>().UpdateAsync(user);
                        ShowViewModel<MainMenuViewModel>();
                    }
                    else
                    {
                        //Not successful login
                    }
                });
            }
        }

        public AuthenticateUserResponse IsAuthenticated()
        {
            AuthenticateUserInput userTry = new AuthenticateUserInput()
            {
                Username = Username,
                Password = Password,
                DeviceName = "as",
                Station = "asd",
                Version = "qwe"
            };
            return Mvx.Resolve<IRestService>().AuthenticateUser(userTry);

        }


    }
}
