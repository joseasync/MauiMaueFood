using IdentityModel.OidcClient;
using MauiMaueFood.Client.ViewModels;
using MauiMaueFood.Client.ViewModels.Auth;

namespace MauiMaueFood.Client;
public static class MauiProgram
{
	public static HttpClient GetInsecureHttpClient()
	{
		#if ANDROID
			var handler = new CustomAndroidMessageHandler();
		#else
			var handler = new HttpClientHandler();
		#endif
		handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
		HttpClient client = new HttpClient(handler);
		return client;
	}
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
	
		
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<Views.Auth.LoginPage>();
		builder.Services.AddSingleton<MainPage>();
		
		builder.Services.AddSingleton<HttpClient>(GetInsecureHttpClient());
        builder.Services.AddTransient<WebAuthenticatorBrowser>();
        
        builder.Services.AddTransient<OidcClient>(sp =>
		new OidcClient(new OidcClientOptions
		{
			Authority = "https://10.0.2.2:5001",
			ClientId = "mauimauefood.appclient",
			Scope = "openid profile api1",
			RedirectUri = "mauimauefoodclient://",
			PostLogoutRedirectUri = "mauimauefoodclient://",
			ClientSecret = "SuperSecretPassword",
			HttpClientFactory = options => GetInsecureHttpClient(), 
			Browser = sp.GetRequiredService<WebAuthenticatorBrowser>()
        }));

        return builder.Build();
	}
}

