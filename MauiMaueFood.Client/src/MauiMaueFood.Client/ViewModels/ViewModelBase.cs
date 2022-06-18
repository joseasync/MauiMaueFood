using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiMaueFood.Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    [ObservableProperty]
    bool isBusy;
    
    public bool IsNotBusy => !IsBusy;
}