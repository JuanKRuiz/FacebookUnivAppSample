using System;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace FacebookUnivAppSample.Manager
{
    partial class FacebookManager
    {
        public async Task LoginAsync()
        {
            var result = await WebAuthenticationBroker.AuthenticateAsync(
                                                        WebAuthenticationOptions.None,
                                                        _loginUrl);

            ValidateAndProccessResult(result);
        }
    }
}
