namespace MedbaseHybrid.Auth
{
    public static class B2CConstants
    {
        // Azure AD B2C Coordinates
        public const string Tenant = "medbasezw.onmicrosoft.com";
        public const string AzureADB2CHostname = "medbasezw.b2clogin.com";
        public const string ClientID = "59206468-8451-4503-b081-79b09b295d1a";
        public static readonly string RedirectUri = $"msal{ClientID}://auth";
        public const string PolicySignUpSignIn = "B2C_1_signupsignin";

        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };

        public static readonly string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static readonly string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";

        public const string IOSKeyChainGroup = "com.companyname.medbasehybrid";
    }
}
