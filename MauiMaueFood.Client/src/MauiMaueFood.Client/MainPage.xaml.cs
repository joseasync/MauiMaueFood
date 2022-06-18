using MauiMaueFood.Client.ViewModels;

namespace MauiMaueFood.Client;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewmodel)
	{
		Shell.SetNavBarIsVisible(this, false);
		InitializeComponent();
		BindingContext = mainViewmodel;
	}
}


