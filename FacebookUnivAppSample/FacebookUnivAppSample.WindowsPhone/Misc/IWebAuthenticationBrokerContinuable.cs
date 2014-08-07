using Windows.ApplicationModel.Activation;

namespace FacebookUnivAppSample.Misc
{
interface IWebAuthenticationBrokerContinuable
{
    void ContinueWithWebAuthenticationBroker(WebAuthenticationBrokerContinuationEventArgs args);
}
}
