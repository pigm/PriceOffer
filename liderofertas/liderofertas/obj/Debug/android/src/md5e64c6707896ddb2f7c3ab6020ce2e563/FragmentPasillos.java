package md5e64c6707896ddb2f7c3ab6020ce2e563;


public class FragmentPasillos
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer,
		android.widget.ExpandableListView.OnGroupClickListener,
		android.widget.ExpandableListView.OnChildClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_onGroupClick:(Landroid/widget/ExpandableListView;Landroid/view/View;IJ)Z:GetOnGroupClick_Landroid_widget_ExpandableListView_Landroid_view_View_IJHandler:Android.Widget.ExpandableListView/IOnGroupClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onChildClick:(Landroid/widget/ExpandableListView;Landroid/view/View;IIJ)Z:GetOnChildClick_Landroid_widget_ExpandableListView_Landroid_view_View_IIJHandler:Android.Widget.ExpandableListView/IOnChildClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppFragments.FragmentPasillos, liderofertas", FragmentPasillos.class, __md_methods);
	}


	public FragmentPasillos ()
	{
		super ();
		if (getClass () == FragmentPasillos.class)
			mono.android.TypeManager.Activate ("liderofertas.AppFragments.FragmentPasillos, liderofertas", "", this, new java.lang.Object[] {  });
	}

	public FragmentPasillos (android.support.v4.app.FragmentManager p0, android.widget.LinearLayout p1, android.widget.LinearLayout p2)
	{
		super ();
		if (getClass () == FragmentPasillos.class)
			mono.android.TypeManager.Activate ("liderofertas.AppFragments.FragmentPasillos, liderofertas", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.Fragment:Android.Widget.LinearLayout, Mono.Android:Android.Widget.LinearLayout, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
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


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public boolean onGroupClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, long p3)
	{
		return n_onGroupClick (p0, p1, p2, p3);
	}

	private native boolean n_onGroupClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, long p3);


	public boolean onChildClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, int p3, long p4)
	{
		return n_onChildClick (p0, p1, p2, p3, p4);
	}

	private native boolean n_onChildClick (android.widget.ExpandableListView p0, android.view.View p1, int p2, int p3, long p4);

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
