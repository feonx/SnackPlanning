package md50137e141328b4101e4122ad814a89fd1;


public abstract class MvxFragmentActivity_1
	extends mvvmcross.droid.support.v4.MvxFragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.Support.V4.MvxFragmentActivity`1, MvvmCross.Droid.Support.Fragment, Version=5.7.0.0, Culture=neutral, PublicKeyToken=null", MvxFragmentActivity_1.class, __md_methods);
	}


	public MvxFragmentActivity_1 ()
	{
		super ();
		if (getClass () == MvxFragmentActivity_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.Support.V4.MvxFragmentActivity`1, MvvmCross.Droid.Support.Fragment, Version=5.7.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
