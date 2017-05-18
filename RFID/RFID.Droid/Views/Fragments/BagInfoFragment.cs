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
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.search_frame)]
    [Register("RFID.Droid.Views.SearchResultFragment")]
    public class BagInfoFragment : BaseFragment<BagInfoViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = ViewModel.BagtagNo;
            ShowBackButton = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_bag_info;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
    }
}