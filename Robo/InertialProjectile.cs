using Microsoft.Xna.Framework;

namespace Robo
{
	public abstract class InertialProjectile : Projectile
	{
		protected Vector2 InertialVelocity { get; set; }

		protected InertialProjectile(BattleScreen screen) : base(screen)
		{
		}

		public override void Update(GameTime gameTime)
		{
			Position += (float)gameTime.ElapsedGameTime.TotalSeconds * InertialVelocity;
		}
	}
}