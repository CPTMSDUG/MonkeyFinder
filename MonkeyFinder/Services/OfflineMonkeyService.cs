namespace MonkeyFinder.Services;

public class OfflineMonkeyService : IMonkeyService
{
    public async Task<IList<Monkey>> GetMonkeys()
    {
        var newMonkeys = new List<Monkey>()
        {
            new Monkey
            {
                Name = "Baboon",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
                Location = "Africa and Asia"
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
                Location = "Central and South America"
            },
            new Monkey
            {
                Name = "Red-shanked douc",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg",
                Location = "Vietnam"
            }
        };

        return newMonkeys;
    }
}
