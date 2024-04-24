namespace Nudgi
{
	public partial class App : Application
	{
		public static TaskViewModel TaskViewModel { get; } = new TaskViewModel();

		public App()
		{
			InitializeComponent();

			MainPage = new MainPage { BindingContext = TaskViewModel };
		}
	}
}
