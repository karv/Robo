using System;
namespace Robo
{
	/// Provides methods to draw objects to a <see cref="DrawingComponent"/>.
	public class Painter
	{
		/// Gets of sets the camera.
		public GameCamera Camera { get; set; }
		/// Gets the gtk component where this class draw.
		public DrawingComponent GtkDrawingComponent { get; }
		/// <param name="gtkDrawingComponent">Gtk drawing component.</param>
		public Painter(DrawingComponent gtkDrawingComponent)
		{ GtkDrawingComponent = gtkDrawingComponent; }

		/// Draw all entities in a collection.
		public void DrawAll(EntityCollection collection)
		{
			foreach (var item in collection)
				item.Draw(this);
		}
	}
}