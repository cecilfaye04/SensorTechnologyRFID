using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using Android.Graphics;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame,true)]
    [Register("RFID.Droid.Views.RfidEncoderFragment")]
    public class RfidEncoderFragment : BaseFragment<RfidEncoderViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "RFID Encoder";
            ShowHamburgerMenu = true;
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

     

        protected override int FragmentId => Resource.Layout.fragment_rfid_encoder;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#283593"));
    }
}