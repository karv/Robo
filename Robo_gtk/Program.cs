using Gtk;

namespace Robo
{
	static class MainClass
	{
		static Game Game;
		public static void Main(string[] args)
		{
			Game = new Game();
			Game.Initialize();

			Application.Init();
			GameWindow win = new GameWindow(Game);
			win.Show();
			Application.Run();
		}
	}
}
