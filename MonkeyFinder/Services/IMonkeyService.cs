namespace MonkeyFinder.Services;

public interface IMonkeyService
{
    Task<IList<Monkey>> GetMonkeys();
}
