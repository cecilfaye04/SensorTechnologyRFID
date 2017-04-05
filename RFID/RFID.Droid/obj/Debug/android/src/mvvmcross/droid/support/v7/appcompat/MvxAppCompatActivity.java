package mvvmcross.droid.support.v7.appcompat;


public class MvxAppCompatActivity
	extends md5ee74959b53a1c6d6b08dfbd4ba8a1175.MvxEventSourceAppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"n_attachBaseContext:(Landroid/content/Context;)V:GetAttachBaseContext_Landroid_content_Context_Handler\n" +
			"n_onCreateView:(Landroid/view/View;Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;:GetOnCreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler\n" +
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.Support.V7.AppCompat.MvxAppCompatActivity, MvvmCross.Droid.Support.V7.AppCompat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxAppCompatActivity.class, __md_methods);
	}


	public MvxAppCompatActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxAppCompatActivity.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.Support.V7.AppCompat.MvxAppCompatActivity, MvvmCross.Droid.Support.V7.AppCompat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);


	public void attachBaseContext (android.content.Context p0)
	{
		n_attachBaseContext (p0);
	}

	private native void n_attachBaseContext (android.content.Context p0);


	public android.view.View onCreateView (android.view.View p0, java.lang.String p1, android.content.Context p2, android.util.AttributeSet p3)
	{
		return n_onCreateView (p0, p1, p2, p3);
	}

	private native android.view.View n_onCreateView (android.view.View p0, java.lang.String p1, android.content.Context p2, android.util.AttributeSet p3);

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
