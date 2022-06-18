using System.Net.Http.Headers;
using System.Text.Json;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels;

[QueryProperty("Token", "Token")]
public partial class MainViewModel : ViewModelBase
{
    protected readonly OidcClient _oidcClient;
    protected readonly HttpClient _httpClient;
    IConnectivity _connectivity;
    public MainViewModel(OidcClient client, HttpClient httpclient, IConnectivity connectivity)
    {
        _oidcClient = client;
        _httpClient = httpclient;
        _connectivity = connectivity;
    }

    [ObservableProperty] private string token;
    
    [ICommand]
    async Task LogoutAsync()
    {
        try
        {
            var loginResult = await _oidcClient.LogoutAsync(new LogoutRequest());
            await Shell.Current.DisplayAlert("Resultado", "Sucesso", "Fechar");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
        }
    }
    
    [ICommand]
    async Task CallApiAsync()
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

            IsBusy = true;
            _httpClient.SetBearerToken(token);
            var response = await _httpClient.GetAsync("https://10.0.2.2:6001/identity");
            if(!response.IsSuccessStatusCode)
                await Shell.Current.DisplayAlert("Api Error", $"{response.StatusCode}", "ok");

            
            var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            var formatted = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            await Shell.Current.DisplayAlert("Token Claims", formatted, "ok");
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