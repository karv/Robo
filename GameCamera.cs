using MonoGame.Extended;

namespace Robo
{
	public class GameCamera : Camera2D
	{
		public GameCamera(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice) : base(graphicsDevice)
		{
		}

		public GameCamera(MonoGame.Extended.ViewportAdapters.ViewportAdapter viewportAdapter) : base(viewportAdapter)
		{
		}
	}
}