using Facebook;
using System;
using Windows.Security.Authentication.Web;

namespace FacebookUnivAppSample.Manager
{
    partial class FacebookManager
    {
        FacebookClient _fb = new FacebookClient();
        readonly Uri _callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
        readonly Uri _loginUrl;

        public string AccessToken
        {
            get { return _fb.AccessToken; }
        }

        public FacebookManager()
        {
            _loginUrl = _fb.GetLoginUrl(new
                    {
                        client_id = App.Current.Resources["FacebookAppId"],
                        redirect_uri = _callbackUri.AbsoluteUri,
                        scope = App.Current.Resources["FacebookPermissions"],
                        display = "popup",
                        response_type = "token"
                    });
        }

        private void ValidateAndProccessResult(WebAuthenticationResult result)
        {
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var responseUri = new Uri(result.ResponseData.ToString());
                var facebookOAuthResult = _fb.ParseOAuthCallbackUrl(responseUri);

                if (string.IsNullOrWhiteSpace(facebookOAuthResult.Error))
                    _fb.AccessToken = facebookOAuthResult.AccessToken;
                else
                {//error de acceso denegado por cancelación en página
                }
            }
            else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {// error de http
            }
            else
            {// otras condiciones de error
            }
        }
    }
}
