using Microsoft.Identity.Client;

namespace MedbaseHybrid.Auth
{
    public class PCAWrapperB2C
    {
        public static PCAWrapperB2C Instance { get; private set; } = new();
        internal IPublicClientApplication PCA { get; }

        private PCAWrapperB2C()
        {
            PCA = PublicClientApplicationBuilder
                                        .Create(B2CConstants.ClientID)
                                        .WithExperimentalFeatures() 
                                        .WithB2CAuthority(B2CConstants.AuthoritySignInSignUp)
                                        .WithIosKeychainSecurityGroup(B2CConstants.IOSKeyChainGroup)
                                        .WithRedirectUri(B2CConstants.RedirectUri)
                                        .Build();
        }

        public async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes)
        {
            // Get accounts by policy
            IEnumerable<IAccount> accounts = await PCA.GetAccountsAsync(B2CConstants.PolicySignUpSignIn);

            AuthenticationResult authResult = await PCA.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
               .WithB2CAuthority(B2CConstants.AuthoritySignInSignUp)
               .ExecuteAsync();

            return authResult;
        }
        internal async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes)
        {
            return await PCA.AcquireTokenInteractive(B2CConstants.Scopes)
                                                        .WithParentActivityOrWindow(PlatformConfig.Instance.ParentWindow)
                                                        .ExecuteAsync();
        }
        internal async Task SignOutAsync()
        {
            var accounts = await PCA.GetAccountsAsync();
            foreach (var acct in accounts)
            {
                await PCA.RemoveAsync(acct);
            }
        }
    }
}
