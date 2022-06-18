using IdentityModel.OidcClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels.Auth;

public partial class LoginViewModel : ViewModelBase
{
    protected readonly OidcClient _client;
    IConnectivity _connectivity;
    public LoginViewModel(OidcClient client, IConnectivity connectivity)
    {
        _client = client;
        _connectivity = connectivity;
    }

    [ICommand]
    async Task LoginAsync()
    {
        if (IsBusy)
            return;
        
        try
        {
            if(_connectivity.NetworkAccess is not NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Offline", "Check sua internet e tente novamente!", "Ok");
                return;
            }
            
            var loginResult = await _client.LoginAsync(new LoginRequest());
            if (loginResult.IsError)
                return;
            
            await Shell.Current.DisplayAlert("Login Result", "Access Token is:\n\n" + loginResult.AccessToken, "Close");
            await Shell.Current.GoToAsync($"{nameof(MainPage)}",true,
                new Dictionary<string, object>
                {
                    {"Token", loginResult.AccessToken }
                });
            
            // Application.Current.MainPage = new MainPage();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
        }
        finally
        {
            IsBusy = false;

        }
    }
    
}