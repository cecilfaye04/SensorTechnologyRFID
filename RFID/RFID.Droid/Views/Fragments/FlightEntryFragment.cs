using Android.OS;
using Android.Runtime;
using Android.Views;
using RFID.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.DepartureFragment")]
    public class FlightEntryFragment : BaseFragment<FlightEntryViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Departure";
            ShowHamburgerMenu = true;
            var mainActivity = Activity as MainMenuView;
            return base.OnCreateView(inflater, container, savedInstanceState); 
        }


        protected override int FragmentId => Resource.Layout.fragment_flight_entry;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#2196F3"));
    }
}