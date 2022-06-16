using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private string isBusy;

    [ICommand]
    async Task LoginAsync()
    {
    }
}