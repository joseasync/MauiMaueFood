using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    private bool isBusy;
    
    public bool IsNotBusy => !IsBusy;
}