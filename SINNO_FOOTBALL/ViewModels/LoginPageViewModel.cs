using SINNO_FOOTBALL.Services;
using SINNO_FOOTBALL.Views;
using System.Windows.Input;

namespace SINNO_FOOTBALL.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    public ICommand GoToHomePageCommand { get; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public LoginPageViewModel(IAuthService authService)
    {
        _authService = authService;
        GoToHomePageCommand = new Command(GoToHomePage, CanExecute);

    }

    public static void GoToHomePage() => Application.Current!.MainPage = new HomePage();
}
