package md5e64c6707896ddb2f7c3ab6020ce2e563;


public class FragmentOfertasUnicas
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppFragments.FragmentOfertasUnicas, liderofertas", FragmentOfertasUnicas.class, __md_methods);
	}


	public FragmentOfertasUnicas ()
	{
		super ();
		if (getClass () == FragmentOfertasUnicas.class)
			mono.android.TypeManager.Activate ("liderofertas.AppFragments.FragmentOfertasUnicas, liderofertas", "", this, new java.lang.Object[] {  });
	}

	public FragmentOfertasUnicas (android.support.v4.app.FragmentManager p0, android.graphics.Bitmap p1)
	{
		super ();
		if (getClass () == FragmentOfertasUnicas.class)
			mono.android.TypeManager.Activate ("liderofertas.AppFragments.FragmentOfertasUnicas, liderofertas", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.Fragment:Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
