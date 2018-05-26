using MonoGame.Extended;

namespace Robo
{
	public interface ICollisionable : IGameEntity
	{
		/// Gets an approximation of a collision.
		RectangleF GetCollisionRectangle();
		bool ExistCollisionWith(ICollisionable other);
	}
}