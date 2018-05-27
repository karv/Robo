using MonoGame.Extended;

namespace Robo
{
	public interface ICollisionable : IGameEntity
	{
		bool ExistCollisionWith(ICollisionable other);

		/// Gets an approximation of a collision.
		RectangleF GetCollisionRectangle();
	}
}