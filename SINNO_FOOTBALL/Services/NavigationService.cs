namespace SINNO_FOOTBALL.Services;

public interface INavigationService
{
    Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

    Task PopAsync();
}

public class NavigationService : INavigationService
{
    public NavigationService() { }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync() =>
        Shell.Current.GoToAsync("..");
}
