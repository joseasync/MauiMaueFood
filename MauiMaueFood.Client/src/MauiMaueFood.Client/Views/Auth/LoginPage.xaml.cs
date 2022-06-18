using MauiMaueFood.Client.ViewModels.Auth;

namespace MauiMaueFood.Client.Views.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginviewmodel)
	{
		InitializeComponent();
		BindingContext = loginviewmodel;
	}
}
