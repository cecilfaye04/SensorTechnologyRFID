using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RFID.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using Android.Graphics;
using static Android.InputMethodServices.InputMethodService;
using MvvmCross.Binding.Droid.BindingContext;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.PierFragment")]
    public class PierFragment : BaseFragment<PierViewModel>
    {
        protected Toolbar Toolbars { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           ((MainView)Activity).Title = "Pier";
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);

        }
        protected override int FragmentId => Resource.Layout.fragment_pier;
    }
}