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
using Android.Support.Design.Widget;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame,true)]
    [Register("RFID.Droid.Views.PierScanFragment")]
    public class PierClaimScanFragment : BaseFragment<PierClaimScanViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
        
            ((MainMenuView)Activity).Title = ViewModel.PierLocation;
            ShowBackButton = true;
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            Button clearButton = view.FindViewById<Button>(Resource.Id.btnClear);
            Button retryButton = view.FindViewById<Button>(Resource.Id.btnRetry);
            clearButton.Click += (s, e) =>
            {
                Snackbar snackBar = Snackbar.Make(clearButton, "Clear", Snackbar.LengthShort).SetAction("OK", (v) =>
                {
                });
                
                snackBar.Show();
            };
            retryButton.Click += (s, e) =>
            {
                Snackbar snackBar = Snackbar.Make(retryButton, "No Internet Connection", Snackbar.LengthShort).SetAction("Retry", (v) =>
                {

                });
                snackBar.Show();
            };
            return view;
        }
        protected override int FragmentId => Resource.Layout.fragment_pier_claim_scan;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#283593"));
    }
}