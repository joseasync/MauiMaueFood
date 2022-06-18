using Android.App;
using Android.Runtime;

namespace MauiMaueFood.Client;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		            // During development, we can trust all certificates, including ASP.NET developer certificates
            // DO NOT ENABLE THIS IN RELEASE BUILDS
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (_, __, ___, ____) => true;
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

