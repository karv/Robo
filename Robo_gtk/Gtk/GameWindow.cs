using System;
using System.Diagnostics;
using Gtk;

namespace Robo
{
	public class DrawingComponent : DrawingArea
	{
		Game Game { get; }
		internal DrawingComponent(Game game)
		{
			Game = game;
		}

		[Conditional("DEBUG")]
		public void DrawTest()
		{
		}

		protected override bool OnExposeEvent(Gdk.EventExpose evnt)
		{
			Debug.WriteLine($"Exposing object. args: {evnt.Count}\t{evnt.Area}:\t{evnt.Region}");
			return base.OnExposeEvent(evnt);
		}
	}

	public class GameWindow : Window
	{
		public DrawingComponent DrawingArea { get; }
		public Game Game { get; }
		public GameWindow(Game game) : base(WindowType.Toplevel)
		{
			Game = game ?? throw new ArgumentNullException(nameof(game));
			DrawingArea = new DrawingComponent(game);
			Add(DrawingArea);
			DeleteEvent += OnDeleteEvent;
			Fullscreen();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected override bool OnExposeEvent(Gdk.EventExpose evnt)
		{
			Debug.WriteLine($"Exposing object. args: {evnt.Count}\t{evnt.Area}:\t{evnt.Region}");
			return base.OnExposeEvent(evnt);
		}
	}
}