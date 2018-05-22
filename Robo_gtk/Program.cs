using Gtk;

namespace Robo
{
	static class MainClass
	{
		static Game Game;
		public static void Main(string[] args)
		{
			Game = new Game();

			//Game.Initialize();
			Game.Run();
		}
	}
}
