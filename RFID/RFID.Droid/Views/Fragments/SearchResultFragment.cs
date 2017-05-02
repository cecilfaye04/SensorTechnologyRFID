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
    [MvxFragment(typeof(MainViewModel), Resource.Id.search_frame,true)]
    [Register("RFID.Droid.Views.SearchResultFragment")]
    public class SearchResultFragment : BaseFragment<SearchResultViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainView)Activity).Title = "0007820706";
            ShowBackButton = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_search_result;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));
    }
}