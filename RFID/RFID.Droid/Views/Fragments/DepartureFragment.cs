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
using MvvmCross.Binding.Droid.BindingContext;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.DepartureFragment")]
    public class DepartureFragment : BaseFragment<DepartureViewModel>
    {
        protected Toolbar Toolbar { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(FragmentId, null);

            ((MainView)Activity).Title = "Departure";
            var mainActivity = Activity as MainView;

            var outer = view.FindViewById<FrameLayout>(Resource.Id.outer);
            //Toolbar toolbar = mainActivity.(Toolbar)findViewById(R.id.toolbar);
            Toolbar = outer.FindViewById<Toolbar>(Resource.Id.toolbar);


            ShowHamburgerMenu = true;
            return view;
        }

        protected override int FragmentId => Resource.Layout.fragment_departure;
    }
}