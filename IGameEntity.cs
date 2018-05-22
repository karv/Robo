using MonoGame.Extended;

namespace Robo
{
	public interface IGameEntity : Moggle.IDrawable
	{
		bool Visible { get; set; }
		Game Game { get; }
		RectangleF Position { get; set; }
	}
}