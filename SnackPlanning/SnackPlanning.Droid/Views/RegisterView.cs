using Android.OS;
using Android.App;

namespace SnackPlanning.Droid.Views
{
    [Activity(Label = "RegisterView")]
    public class RegisterView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.RegisterView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}
