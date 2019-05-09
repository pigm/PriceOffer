package md5fd4b1f464e42e894969c90b16944668c;


public class LoadingDialog
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppDialogs.LoadingDialog, liderofertas", LoadingDialog.class, __md_methods);
	}


	public LoadingDialog ()
	{
		super ();
		if (getClass () == LoadingDialog.class)
			mono.android.TypeManager.Activate ("liderofertas.AppDialogs.LoadingDialog, liderofertas", "", this, new java.lang.Object[] {  });
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
