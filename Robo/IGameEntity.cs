using MonoGame.Extended;

namespace Robo
{
	public interface IGameEntity : Moggle.IDrawable, IUpdate
	{
		bool Visible { get; set; }
		Game Game { get; }
		// TODO: Remove this setter and make "offset" method
		RectangleF Position { get; set; }
	}
}