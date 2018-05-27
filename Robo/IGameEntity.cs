using MonoGame.Extended;

namespace Robo
{
	public interface IGameEntity : Moggle.IDrawable, IUpdate
	{
		Game Game { get; }

		// TODO: Remove this setter and make "offset" method
		RectangleF Position { get; set; }

		bool Visible { get; set; }
	}
}