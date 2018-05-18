using System;
namespace Robo
{
	public class Painter
	{
		public ConsoleCamera Camera { get; set; }
		public DrawingComponent GtkDrawingComponent { get; }
		public Painter(DrawingComponent gtkDrawingComponent)
		{
			GtkDrawingComponent = gtkDrawingComponent;
		}

		public void DrawAll()
		{
			throw new NotImplementedException();
		}
	}
}