package md5cf32c5c5857e96e915a7f267e2e3541c;


public class AdapterProductoRelacionado_ProductoRelacionadoViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("liderofertas.AppAdapters.AdapterProductoRelacionado+ProductoRelacionadoViewHolder, liderofertas", AdapterProductoRelacionado_ProductoRelacionadoViewHolder.class, __md_methods);
	}


	public AdapterProductoRelacionado_ProductoRelacionadoViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == AdapterProductoRelacionado_ProductoRelacionadoViewHolder.class)
			mono.android.TypeManager.Activate ("liderofertas.AppAdapters.AdapterProductoRelacionado+ProductoRelacionadoViewHolder, liderofertas", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
