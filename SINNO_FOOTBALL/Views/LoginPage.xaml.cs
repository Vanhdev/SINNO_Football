using SINNO_FOOTBALL.ViewModels;

namespace SINNO_FOOTBALL.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();

		BindingContext = loginPageViewModel;
	}
}