using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	/// A common implementation for beam, projectile, or any other short-living disposable entity.
	public abstract class Projectile : IGameEntity, IDisposable, ICollisionable
	{
		public bool Visible { get; set; }

		public Game Game => (Game)Screen.Game;
		public BattleScreen Screen { get; }

		RectangleF IGameEntity.Position
		{
			get => GetCollisionRectangle();
			set => throw new NotImplementedException();
		}

		public Vector2 Position { get; set; }
		bool IGameEntity.Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		Game IGameEntity.Game => throw new NotImplementedException();

		protected Projectile(BattleScreen screen)
		{ Screen = screen ?? throw new ArgumentNullException(nameof(screen)); }

		public void AddToBattlefield()
		{
			Screen.AddWhenSafe(this);
		}

		public void Destroy()
		{
			Screen.RemoveWhenSafe(this);
			Dispose();
		}

		public virtual RectangleF GetCollisionRectangle() => new RectangleF(Position, Size2.Empty);
		public virtual bool ExistCollisionWith(ICollisionable other) => true;

		public abstract void Draw(SpriteBatch batch);

		public virtual void Initialize() { }

		public abstract void Update(GameTime gameTime);

		public virtual void Dispose() { }
	}
}