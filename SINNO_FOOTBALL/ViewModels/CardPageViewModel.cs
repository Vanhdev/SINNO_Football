using System.Windows.Input;

namespace SINNO_FOOTBALL.ViewModels;

public class CardPageViewModel : BaseViewModel
{
    public Document? member;

    public ICommand GoToDetailCommand { get; }

    public CardPageViewModel() : base()
    {
        GoToDetailCommand = new Command(GotoDetailPage, CanExecute);
    }

    public static async void GotoDetailPage()
    {
        await Shell.Current.GoToAsync("Detail");
    }
}
