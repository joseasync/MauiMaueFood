using IdentityModel.OidcClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels.Auth;

public partial class LoginViewModel : ViewModelBase
{
    protected readonly OidcClient _client;

    public LoginViewModel(OidcClient client)
    {
        _client = client;
    }
    // For Firebase Video :D
    // [ObservableProperty] private string login;
    //
    // [ObservableProperty] private string password;
    
    [ICommand]
    async Task LoginAsync()
    {
        try
        {
            var loginResult = await _client.LoginAsync(new LoginRequest());
            if (loginResult.IsError)
                return;
            
            await Shell.Current.DisplayAlert("Login Result", "Access Token is:\n\n" + loginResult.AccessToken, "Close");
            await Shell.Current.GoToAsync($"{nameof(MainPage)}",true,
                new Dictionary<string, object>
                {
                    {"Token", loginResult.AccessToken }
                });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
        }
    }
    
}