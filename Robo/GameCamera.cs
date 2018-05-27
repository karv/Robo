using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Robo
{
	public class GameCamera : Camera2D
	{
		public Vector2 DefaultPosition { get; }
		public float DefaultZoom { get; }

		public GameCamera(MonoGame.Extended.ViewportAdapters.ViewportAdapter viewportAdapter) : base(viewportAdapter)
		{
			DefaultPosition = Position;
			DefaultZoom = Zoom;
		}

		public void Reset()
		{
			Position = DefaultPosition;
			Zoom = DefaultZoom;
		}
	}
}