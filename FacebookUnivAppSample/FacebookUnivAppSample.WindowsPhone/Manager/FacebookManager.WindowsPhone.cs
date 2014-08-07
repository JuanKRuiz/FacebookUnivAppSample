using Windows.ApplicationModel.Activation;
using Windows.Security.Authentication.Web;

namespace FacebookUnivAppSample.Manager
{
    partial class FacebookManager
    {
        public void LoginAndContinue()
        {
            WebAuthenticationBroker.AuthenticateAndContinue(_loginUrl);
        }

        public void ContinueAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            ValidateAndProccessResult(args.WebAuthenticationResult);
        }
    }
}
