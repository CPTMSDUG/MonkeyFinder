namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), MonkeyQueryParameter)]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    public const string MonkeyQueryParameter = "Monkey";

    private readonly IMap mapService;
    private Monkey monkey;

    public MonkeyDetailsViewModel(IMap mapService)
    {
        this.mapService = mapService;

        OpenMapCommand = new Command(OpenMap);
    }

    public Command OpenMapCommand { get; }

    public Command BackCommand { get; }

    public Monkey Monkey
    {
        get => monkey;
        set
        {
            monkey = value;
            OnPropertyChanged();
        }
    }

    private async void OpenMap()
    {
        await mapService.OpenAsync(new Location(Monkey.Latitude, Monkey.Longitude));
    }
}
