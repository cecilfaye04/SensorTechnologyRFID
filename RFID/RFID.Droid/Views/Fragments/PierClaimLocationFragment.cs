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
using static Android.Views.View;
using Android.Graphics.Drawables;
using MvvmCross.Platform.Droid.WeakSubscription;
using System.ComponentModel;
using MvvmCross.Platform.WeakSubscription;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.PierFragment")]
    public class PierClaimLocationFragment : BaseFragment<PierClaimLocationViewModel>
    {
        protected Toolbar Toolbars { get; private set; }
        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;
        int previousGroup = -1;
        MvxNotifyPropertyChangedEventSubscription _token;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
           ((MainMenuView)Activity).Title = ViewModel.pierClaimFlag;
            View view = base.OnCreateView(inflater, container, savedInstanceState);
            expListView = view.FindViewById<ExpandableListView>(Resource.Id.lvPierLocation);
            return view;
        }

        public override void OnResume()
        {
            _token = ViewModel.WeakSubscribe(ViewModelPropertyChanged);
            ViewModel.InitializeList();
            base.OnResume();
        }
     
        public override void OnPause()
        {
            _token.Dispose();
            base.OnPause();
        }

        //Failed solution for navigating from Pier to Claim (need to dispose instance of the fragment)
        //public override void OnViewCreated(View view, Bundle savedInstanceState)
        //{
        //    var mainActivity = Activity as MainMenuView;
        //    //this.Dispose();
        //    var fragmentActivity = mainActivity as Android.Support.V4.App.FragmentActivity;
        //    //fragmentActivity.SupportFragmentManager.BeginTransaction().Remove(this).Commit();
        //}
        //public override void OnDestroy()
        //{
        //    this.Dispose();
        //}


        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "PierResponse")
            {
                if (ViewModel.PierResponse != null)
                {
                    GetPierLocations();
                    var mainActivity = Activity as MainMenuView;
                    listAdapter = new ExpandableListAdapter(mainActivity, listDataHeader, listDataChild);
                    expListView.SetAdapter(listAdapter);
                    FnClickEvents();
                }
            }
        }

        void GetPierLocations()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();
                foreach (var item in ViewModel.PierResponse.MainLocations)
                {
                    listDataHeader.Add(item.Name);
                    listDataChild.Add(item.Name, item.SubLocations.ToList());
                }
        }
   
        void FnClickEvents()
        {
            //Listening to child item selection
            string result = String.Empty;
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) {
                ViewModel.PierLocation = listAdapter.GetChild(e.GroupPosition, e.ChildPosition).ToString();
                ViewModel.ShowPierScanCommand.Execute();
            };

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e) {

                if (e.GroupPosition != previousGroup)
                    expListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };

            //Listening to group collapse
            expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e) {
                //Toast.MakeText(this, "group collapsed", ToastLength.Short).Show();
            };
        }
        protected override int FragmentId => Resource.Layout.fragment_pier_claim_location;

        //protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#283593"));

        protected override ColorDrawable backcolor
        {
            get
            {
                if (ViewModel.pierClaimFlag == "Pier")
                {
                    return new ColorDrawable(Color.ParseColor("#283593"));
                }
                else if (ViewModel.pierClaimFlag == "Claim")
                {
                    return new ColorDrawable(Color.ParseColor("#4b2554"));
                }
                else
                {
                    return new ColorDrawable(Color.ParseColor("#0a022d"));
                }
            }
        }
    }
}