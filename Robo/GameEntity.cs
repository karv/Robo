﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	/// Base class for common game entity :
	/// <see cref="IGameEntity"/>
	public abstract class GameEntity : IGameEntity, Moggle.IDrawable
	{
		/// Gets the
		/// <see cref="Game"/>
		/// class.
		public Game Game { get; internal set; }

		public RectangleF Position { get; set; }

		/// Gets or sets the visibility status of this entity.
		public bool Visible { get; set; } = true;

		public virtual void Displace(Vector2 delta) => Game.Displacer.Displace(this, delta);

		/// Draw using the specified
		/// <see cref="T:Microsoft.Xna.Framework.Graphics.SpriteBatch"/>
		/// .
		public abstract void Draw(SpriteBatch batch);

		/// Initialize this object.
		public virtual void Initialize() { }

		public virtual void Update(GameTime gameTime)
		{
		}
	}
}