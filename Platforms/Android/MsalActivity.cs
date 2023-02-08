using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace MedbaseHybrid.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal59206468-8451-4503-b081-79b09b295d1a")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
