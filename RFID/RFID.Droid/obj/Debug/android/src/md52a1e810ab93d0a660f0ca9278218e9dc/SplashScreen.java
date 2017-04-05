package md52a1e810ab93d0a660f0ca9278218e9dc;


public class SplashScreen
	extends mvvmcross.droid.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RFID.Droid.SplashScreen, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashScreen.class, __md_methods);
	}


	public SplashScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SplashScreen.class)
			mono.android.TypeManager.Activate ("RFID.Droid.SplashScreen, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
