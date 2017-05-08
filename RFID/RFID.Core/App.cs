using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using RFID.Core.Interfaces;
using RFID.Core.Services;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static SQLiteAsyncConnection Connection { get; set; }

        public async override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            await Mvx.Resolve<IInitilializeSqliteService>().InitializeAsync();
            var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
            if (user.IsLoggedIn)
            { this.RegisterAppStart<ViewModels.MainMenuViewModel>(); }
            else { this.RegisterAppStart<ViewModels.LoginViewModel>(); }

        }
    }
}
