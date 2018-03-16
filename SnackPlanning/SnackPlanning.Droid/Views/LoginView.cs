using Android.App;
using Android.OS;

namespace SnackPlanning.Droid.Views
{
    [Activity(Label = "LoginView")]
    public class LoginView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.LoginView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}
