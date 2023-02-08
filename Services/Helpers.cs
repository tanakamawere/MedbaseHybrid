namespace MedbaseHybrid.Services
{
    public class Helpers
    {
        public static bool InternetAvailable()
        {
            bool internet = false;
            NetworkAccess access = Connectivity.Current.NetworkAccess;

            if (access == NetworkAccess.Internet)
                internet = true;
            else if (access == NetworkAccess.None || access == NetworkAccess.Unknown)
                internet = false;

            return internet;
        }
        public static bool CheckSubscription()
        {
            bool active = false;
            if (Preferences.ContainsKey(Constants.SubscriptionPreferenceDate()))
            {
                DateTime subEndDate = DateTime.Parse(Preferences.Get(Constants.SubscriptionPreferenceDate(), "01/01/2099"));

                int subActive = subEndDate.Date.CompareTo(DateTime.Now.Date);
                if (subActive > 0)
                {
                    //This means the user's subscription is active.
                    active = true;
                }
            }
            return active;
        }

        public static void RemoveSubscription()
        {
            if (Preferences.ContainsKey(Constants.SubscriptionPreferenceDate()))
            {
                Preferences.Remove(Constants.SubscriptionPreferenceDate());
            }
            else return;
        }

        public static bool CheckForSubPreference()
        {
            bool result = false;
            if (Preferences.ContainsKey(Constants.SubscriptionPreferenceDate()))
            {
                result = true;
            }
            return result;
        }

        public static async Task<bool> CheckForStoragePermission()
        {
            bool permitted = false;
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Granted)
                permitted = true;

            return permitted;
        }
    }
}
