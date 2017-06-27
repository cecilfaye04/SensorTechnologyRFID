using Android.Content.Res;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace RFID.Droid.Views
{
    public abstract class BaseFragment : MvxFragment
    {
        protected Toolbar Toolbar { get; private set; }
        protected MvxActionBarDrawerToggle DrawerToggle { get; private set; }
        /// <summary>
        /// If true show the hamburger menu
        /// </summary>
        protected bool ShowHamburgerMenu { get; set; } = false;
        protected bool ShowBackButton { get; set; } = false;
        protected bool ShowBackMenu { get; set; } = false;

        protected BaseFragment()
        {
            RetainInstance = true;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                var mainActivity = Activity as MainMenuView;
                if (mainActivity == null) return view;

                mainActivity.SetSupportActionBar(Toolbar);

                if (ShowHamburgerMenu)
                {
                    mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

                    DrawerToggle = new MvxActionBarDrawerToggle(
                        Activity,                               // host Activity
                        mainActivity.DrawerLayout,  // DrawerLayout object
                        Toolbar,                               // nav drawer icon to replace 'Up' caret
                        Resource.String.drawer_open,            // "open drawer" description
                        Resource.String.drawer_close            // "close drawer" description
                    ); 

                    DrawerToggle.DrawerOpened += (sender, e) => mainActivity?.HideSoftKeyboard();
                    mainActivity.DrawerLayout.AddDrawerListener(DrawerToggle);
                }
                else if (ShowBackButton)
                {
                    mainActivity.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
                }
                mainActivity.SupportActionBar?.SetBackgroundDrawable(backcolor);
            }

            return view;
        }

        protected abstract int FragmentId { get; }
        protected abstract ColorDrawable backcolor { get; }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (Toolbar != null)
            {
                DrawerToggle?.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (Toolbar != null)
            {
                DrawerToggle?.SyncState();
            }
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
