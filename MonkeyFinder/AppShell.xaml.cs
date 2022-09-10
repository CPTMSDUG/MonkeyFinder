namespace MonkeyFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        // routes
        //  - /monkeys               => main page
        //  - /monkeys/profile       => details page
        //  - /monkeys/profile/edit  => edit profile page
        //  - /settings
        //  - /about

        Routing.RegisterRoute("monkeys/profile", typeof(DetailsPage));
	}
}