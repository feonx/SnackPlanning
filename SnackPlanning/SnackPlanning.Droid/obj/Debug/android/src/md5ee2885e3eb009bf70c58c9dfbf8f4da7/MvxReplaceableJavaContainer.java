package md5ee2885e3eb009bf70c58c9dfbf8f4da7;


public class MvxReplaceableJavaContainer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"";
		mono.android.Runtime.register ("MvvmCross.Platform.Droid.MvxReplaceableJavaContainer, MvvmCross.Platform.Droid, Version=5.7.0.0, Culture=neutral, PublicKeyToken=null", MvxReplaceableJavaContainer.class, __md_methods);
	}


	public MvxReplaceableJavaContainer ()
	{
		super ();
		if (getClass () == MvxReplaceableJavaContainer.class)
			mono.android.TypeManager.Activate ("MvvmCross.Platform.Droid.MvxReplaceableJavaContainer, MvvmCross.Platform.Droid, Version=5.7.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();

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
