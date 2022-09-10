using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly IMonkeyService service;
    private readonly IGeolocation gps;
    private readonly ILogger<MonkeysViewModel> logger;
    private readonly IConnectivity connectivity;

    public MonkeysViewModel(
        IMonkeyService service,
        IGeolocation gps,
        ILogger<MonkeysViewModel> logger,
        IConnectivity connectivity)
    {
        this.service = service;
        this.gps = gps;
        this.logger = logger;
        this.connectivity = connectivity;
        Monkeys = new ObservableCollection<Monkey>();
        GoToProfileCommand = new Command<Monkey>(GoToProfile);
        NearestCommand = new Command(FindNearest);

        LoadData();
    }

    public ObservableCollection<Monkey> Monkeys { get; }

    public Command GoToProfileCommand { get; }

    public Command NearestCommand { get; }

    async void LoadData()
    {
        if (IsLoading)
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Error", "No internet! Booo!", "Thanks!");
            return;
        }

        IsLoading = true;

        try
        {
            var newMonkeys = await service.GetMonkeys();
            foreach (var monkey in newMonkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading monkeys!");
        }

        IsLoading = false;
    }

    private async void GoToProfile(Monkey monkey)
    {
        await Shell.Current.GoToAsync("profile", new Dictionary<string, object>
        {
            [MonkeyDetailsViewModel.MonkeyQueryParameter] = monkey
        });
    }

    private async void FindNearest()
    {
        if (IsLoading)
            return;

        IsLoading = true;

        var location = await gps.GetLocationAsync();

        var nearest = Monkeys
            .OrderBy(m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers))
            .FirstOrDefault();

        GoToProfile(nearest);

        IsLoading = false;
    }
}
