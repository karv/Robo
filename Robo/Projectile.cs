using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	/// A common implementation for beam, projectile, or any other short-living disposable entity.
	public abstract class Projectile : IGameEntity, IDisposable, ICollisionable
	{
		public DeployedRobot Origin { get; set; }
		public Vector2 Position { get; set; }
		public BattleScreen Screen { get; }
		public bool Visible { get; set; }
		Game IGameEntity.Game => throw new NotImplementedException();
		public Game Game => (Game)Screen.Game;

		RectangleF IGameEntity.Position
		{
			get => GetCollisionRectangle();
			set => throw new NotImplementedException();
		}

		bool IGameEntity.Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

		public virtual void Dispose()
		{
		}

		public abstract void Draw(SpriteBatch batch);

		public virtual bool ExistCollisionWith(ICollisionable other) => true;

		public virtual RectangleF GetCollisionRectangle() => new RectangleF(Position, new Size2(1, 1));

		public virtual void Initialize()
		{
		}

		public abstract void Update(GameTime gameTime);
	}
}