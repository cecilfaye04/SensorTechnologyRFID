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

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.PierFragment")]
    public class PierFragment : BaseFragment<PierViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);

        }

        protected override int FragmentId => Resource.Layout.fragment_pier;
    }
}