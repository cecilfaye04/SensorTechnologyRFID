using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RFID.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using Android.Graphics.Drawables;
using Android.Graphics;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using MvvmCross.Binding.Droid.BindingContext;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.DepartureFragment")]
    public class DepartureFragment : BaseFragment<DepartureViewModel>
    {
        //protected Toolbar Toolbar { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            //var view = this.BindingInflate(FragmentId, null);
            ((MainView)Activity).Title = "Departure";
            ShowHamburgerMenu = true;
            var mainActivity = Activity as MainView;
            //var tool = mainActivity.FindViewById<Toolbar>(Resource.Id.toolbar);

            //mainActivity.SetSupportActionBar(tool);
            //mainActivity.SupportActionBar.SetBackgroundDrawable(new ColorDrawable(Color.Black));
            
            //mainActivity.SupportActionBar?.SetDisplayShowTitleEnabled(true);
            //mainActivity.SupportActionBar?.SetDisplayShowTitleEnabled(false);
            //bar.SetBackgroundDrawable(colorDrawable);
            return base.OnCreateView(inflater, container, savedInstanceState); 
        }


        protected override int FragmentId => Resource.Layout.fragment_departure;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#2196F3"));
    }
}