package md54a184fbf65227cb06041379576d28d5e;


public class MyErrorHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		kotlin.jvm.functions.Function1,
		kotlin.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invoke:(Ljava/lang/Object;)Ljava/lang/Object;:GetInvoke_Ljava_lang_Object_Handler:Kotlin.Jvm.Functions.IFunction1Invoker, Estimote.Android.Proximity\n" +
			"";
		mono.android.Runtime.register ("liderofertas.AppUtils.MyErrorHandler, liderofertas", MyErrorHandler.class, __md_methods);
	}


	public MyErrorHandler ()
	{
		super ();
		if (getClass () == MyErrorHandler.class)
			mono.android.TypeManager.Activate ("liderofertas.AppUtils.MyErrorHandler, liderofertas", "", this, new java.lang.Object[] {  });
	}

	public MyErrorHandler (md5473ad1a8c21358ee6d1b45a28116bbeb.HomeOfertasActivity p0, java.lang.String p1)
	{
		super ();
		if (getClass () == MyErrorHandler.class)
			mono.android.TypeManager.Activate ("liderofertas.AppUtils.MyErrorHandler, liderofertas", "liderofertas.AppActivitys.HomeOfertasActivity, liderofertas:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public java.lang.Object invoke (java.lang.Object p0)
	{
		return n_invoke (p0);
	}

	private native java.lang.Object n_invoke (java.lang.Object p0);

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
