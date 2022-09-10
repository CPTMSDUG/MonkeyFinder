namespace MonkeyFinder.ViewModel;

public class BaseViewModel : BindableObject
{
    private bool isLoading;

    public bool IsLoading
    {
        get => isLoading;
        set
        {
            isLoading = value;
            OnPropertyChanged();
        }
    }
}
