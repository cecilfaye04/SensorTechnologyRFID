package md5269bd7252ef3cb797ab39a922385c683;


public abstract class BaseFragment_1
	extends md5269bd7252ef3cb797ab39a922385c683.BaseFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RFID.Droid.Views.BaseFragment`1, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseFragment_1.class, __md_methods);
	}


	public BaseFragment_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BaseFragment_1.class)
			mono.android.TypeManager.Activate ("RFID.Droid.Views.BaseFragment`1, RFID.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
