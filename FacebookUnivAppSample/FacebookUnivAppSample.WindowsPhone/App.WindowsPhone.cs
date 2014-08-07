using FacebookUnivAppSample.Common;
using FacebookUnivAppSample.Manager;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FacebookUnivAppSample
{
    public sealed partial class App : Application
    {
        ContinuationManager _continuator = new ContinuationManager();
        protected async override void OnActivated(IActivatedEventArgs args)
        {
            CreateRootFrame();

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                try
                {
                    await SuspensionManager.RestoreAsync();
                }
                catch { }
            }

            if (args is IContinuationActivatedEventArgs)
                _continuator.ContinueWith(args);

            Window.Current.Activate();
        }

        private void CreateRootFrame()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                Window.Current.Content = rootFrame;
            }
        }
    }
}
