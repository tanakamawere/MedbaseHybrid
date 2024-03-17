using MedbaseHybrid.MsalClient;

namespace MedbaseHybrid.Services
{
    public static class Helpers
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
        public static async Task<bool> CheckForStoragePermission()
        {
            bool permitted = false;
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Granted)
                permitted = true;

            return permitted;
        }
        public static string[] ToStringArray(this NestedSettings[] nestedSettings)
        {
            var result = new string[nestedSettings.Length];

            for (int i = 0; i < nestedSettings.Length; i++)
            {
                result[i] = nestedSettings[i].Value;
            }

            return result!;
        }
    }
}
