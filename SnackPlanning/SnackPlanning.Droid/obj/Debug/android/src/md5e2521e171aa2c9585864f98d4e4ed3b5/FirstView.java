package md5e2521e171aa2c9585864f98d4e4ed3b5;


public class FirstView
	extends md5e2521e171aa2c9585864f98d4e4ed3b5.BaseView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SnackPlanning.Droid.Views.FirstView, SnackPlanning.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FirstView.class, __md_methods);
	}


	public FirstView ()
	{
		super ();
		if (getClass () == FirstView.class)
			mono.android.TypeManager.Activate ("SnackPlanning.Droid.Views.FirstView, SnackPlanning.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
