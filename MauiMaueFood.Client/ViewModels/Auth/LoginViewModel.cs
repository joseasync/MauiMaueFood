using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels.Auth;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty] private string login;

    [ObservableProperty] private string password;
    
    [ICommand]
    async Task LoginAsync()
    {
        
    }
    
}