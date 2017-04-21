using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;

namespace RFID.Droid.Views.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame,true)]
    [Register("RFID.Droid.Views.SearchTrackFragment")]
    public class SearchTrackFragment : BaseFragment<SearchTrackViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainView)Activity).Title = "Jennifer Smith's Bag";
            ShowBackButton = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        protected override int FragmentId => Resource.Layout.fragment_search_track;
    }
}