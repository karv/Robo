﻿using CE;

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

		/// Draw this entity using the specified <see cref="Painter"/>.
		public abstract void Draw(Painter painter);
		/// Initialize this object.
		public virtual void Initialize() { }

		public virtual void Displace(PointF delta) => Game.Displacer.Displace(this, delta);
	}
}