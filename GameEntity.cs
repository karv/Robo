using CE;
using Microsoft.Xna.Framework.Graphics;

namespace Robo
{
	/// Base class for common game entity : <see cref="IGameEntity"/>
	public abstract class GameEntity : IGameEntity
	{
		/// Gets the <see cref="Game"/>class.
		public Game Game { get; internal set; }
		/// Gets or sets the visibility status of this entity.
		public bool Visible { get; set; } = true;

		public RectangleF Position { get; set; }

		/// Initialize this object.
		public virtual void Initialize() { }

		public virtual void Displace(PointF delta) => Game.Displacer.Displace(this, delta);

		/// Draw using the specified <see cref="T:Microsoft.Xna.Framework.Graphics.SpriteBatch" />.
		public abstract void Draw(SpriteBatch batch);
	}
}