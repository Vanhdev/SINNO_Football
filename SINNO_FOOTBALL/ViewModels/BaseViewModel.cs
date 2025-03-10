using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SINNO_FOOTBALL.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    private bool _isRefreshing;
    public ICommand? RefreshCommand { get; set; }

    public bool IsBusy
    {
        get { return _isBusy; }
        set
        {
            _isBusy = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public bool IsNotBusy
    {
        get => !IsBusy;
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    public BaseViewModel()
    {
        RefreshCommand = new Command(() => Refresh());
    }

    public bool CanExecute() => IsNotBusy && !IsRefreshing;

    public virtual Task Refresh()
    {
        IsRefreshing = false;

        return Task.CompletedTask;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }
}
