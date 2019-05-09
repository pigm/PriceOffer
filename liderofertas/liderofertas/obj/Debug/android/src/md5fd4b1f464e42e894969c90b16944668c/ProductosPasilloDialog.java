package md5fd4b1f464e42e894969c90b16944668c;


public class ProductosPasilloDialog
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppDialogs.ProductosPasilloDialog, liderofertas", ProductosPasilloDialog.class, __md_methods);
	}


	public ProductosPasilloDialog ()
	{
		super ();
		if (getClass () == ProductosPasilloDialog.class)
			mono.android.TypeManager.Activate ("liderofertas.AppDialogs.ProductosPasilloDialog, liderofertas", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

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
