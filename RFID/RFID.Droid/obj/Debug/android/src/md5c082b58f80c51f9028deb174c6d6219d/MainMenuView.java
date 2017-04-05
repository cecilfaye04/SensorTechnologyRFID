package md5c082b58f80c51f9028deb174c6d6219d;


public class MainMenuView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RFID.Droid.Views.Activities.MainMenuView, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainMenuView.class, __md_methods);
	}


	public MainMenuView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainMenuView.class)
			mono.android.TypeManager.Activate ("RFID.Droid.Views.Activities.MainMenuView, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
