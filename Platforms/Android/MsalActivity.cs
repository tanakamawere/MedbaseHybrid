
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace MsalAuthInMaui.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal4f63e9d9-9f26-4858-af01-6d14cd772141")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}