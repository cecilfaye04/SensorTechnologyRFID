using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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
                return new MvxCommand(async () =>
                {
                    //if (await _service.ValidateLogin(Username, Password))
                    //{
                    var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
                    user.IsLoggedIn = true;
                    await Mvx.Resolve<ISqliteService>().UpdateAsync(user);
                    ShowViewModel<MainMenuViewModel>();
                    //}
                    //else
                    //{
                    //    _udialog.Alert("Incorrect Username or Password");
                    //}
                });
            }
        }


    }
}
