namespace MonkeyFinder.Services;

public class OnlineMonkeyService : IMonkeyService
{
    private const string MonkeyRequestUri = "https://www.montemagno.com/monkeys.json";

    private readonly HttpClient httpClient;

    public OnlineMonkeyService()
    {
        httpClient = new HttpClient();
    }

    public async Task<IList<Monkey>> GetMonkeys()
    {
        var monkeys = await httpClient.GetStringAsync(MonkeyRequestUri);
        return JsonSerializer.Deserialize<IList<Monkey>>(monkeys);
    }
}