package md5cf32c5c5857e96e915a7f267e2e3541c;


public class GenericFragmentPageAdapterTabs
	extends android.support.v4.app.FragmentStatePagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getItem:(I)Landroid/support/v4/app/Fragment;:GetGetItem_IHandler\n" +
			"n_getPageTitle:(I)Ljava/lang/CharSequence;:GetGetPageTitle_IHandler\n" +
			"n_saveState:()Landroid/os/Parcelable;:GetSaveStateHandler\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppAdapters.GenericFragmentPageAdapterTabs, liderofertas", GenericFragmentPageAdapterTabs.class, __md_methods);
	}


	public GenericFragmentPageAdapterTabs (android.support.v4.app.FragmentManager p0)
	{
		super (p0);
		if (getClass () == GenericFragmentPageAdapterTabs.class)
			mono.android.TypeManager.Activate ("liderofertas.AppAdapters.GenericFragmentPageAdapterTabs, liderofertas", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.Fragment", this, new java.lang.Object[] { p0 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.support.v4.app.Fragment getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native android.support.v4.app.Fragment n_getItem (int p0);


	public java.lang.CharSequence getPageTitle (int p0)
	{
		return n_getPageTitle (p0);
	}

	private native java.lang.CharSequence n_getPageTitle (int p0);


	public android.os.Parcelable saveState ()
	{
		return n_saveState ();
	}

	private native android.os.Parcelable n_saveState ();

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
