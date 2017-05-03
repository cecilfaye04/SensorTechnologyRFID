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


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            ShowHamburgerMenu = true;
            ((MainMenuView)Activity).Title = "Pier";
            var mainActivity = Activity as MainMenuView;
            View view = base.OnCreateView(inflater, container, savedInstanceState);
            expListView = view.FindViewById<ExpandableListView>(Resource.Id.lvPierLocation);
            FnGetListData();
            listAdapter = new ExpandableListAdapter(mainActivity, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);
            FnClickEvents();
            mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            return view;

        }

   
        void FnGetListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("Pier 1");
            listDataHeader.Add("Pier 2");
            listDataHeader.Add("Pier 3");
            listDataHeader.Add("Pier 4");

            // Adding child data
            var pier1 = new List<string>();
            pier1.Add("Location 1");
            pier1.Add("Location 2");
            pier1.Add("Location 3");
            pier1.Add("Location 4");
            pier1.Add("Location 5");

            var pier2 = new List<string>();
            pier2.Add("Location 1");
            pier2.Add("Location 2");
            pier2.Add("Location 3");
            pier2.Add("Location 4");
            pier2.Add("Location 5");

            var pier3 = new List<string>();
            pier3.Add("Location 1");
            pier3.Add("Location 2");
            pier3.Add("Location 3");
            pier3.Add("Location 4");
            pier3.Add("Location 5");

            var pier4 = new List<string>();
            pier4.Add("Location 1");
            pier4.Add("Location 2");
            pier4.Add("Location 3");
            pier4.Add("Location 4");
            pier4.Add("Location 5");

            // Header, Child data
            listDataChild.Add(listDataHeader[0], pier1);
            listDataChild.Add(listDataHeader[1], pier2);
            listDataChild.Add(listDataHeader[2], pier3);
            listDataChild.Add(listDataHeader[3], pier4);
        }

        void FnClickEvents()
        {
            //Listening to child item selection
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) {
                ViewModel.ShowPierScanCommand.Execute();
                //Toast.MakeText(this, "child clicked", ToastLength.Short).Show();
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
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#283593"));
    }
}