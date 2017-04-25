using App11.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App11
{
	public partial class App : Application
	{
		static CharacterDB database;

		public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new MainMenuPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }

		public static CharacterDB Database
		{
			get
			{
				if (database == null)
				{
					database = new CharacterDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("CharacterSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtCharacterId { get; set; }
	}
}
