using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	public class SlowLaserBeam : InertialProjectile
	{
		public float Energy
		{
			get => _energy;
			set
			{
				_energy = value;
				if (_energy <= 0)
				{
					Dissipated?.Invoke(this, EventArgs.Empty);
					Destroy();
				}
			}
		}

		public float EnergyLoseRatio { get; set; }

		public Vector2 Direction { get; set; } //TODO: Force unitary or zero.
		public float Velocity
		{
			get => InertialVelocity.Length();
			set => InertialVelocity = Direction * value;
		}

		public SlowLaserBeam(BattleScreen screen) : base(screen) { }

		public override void Draw(SpriteBatch batch)
		{
			// Do not draw zero-speed beam.
			if (Vector2.Zero == Direction) return;
			var dir = (float)Math.Atan2(Direction.Y, Direction.X);
			var transparency = Energy < 1 ? Energy : 1;
			batch.DrawLine(Position, Length, dir, Color * transparency, Thickness);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			Energy -= EnergyLoseRatio * (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		/// Occurs when it lost all of its energy.
		public event EventHandler Dissipated;
		float _energy;

		public const float Length = 100;
		public const int Thickness = 7;
		public static Color Color => Color.Red;
	}
}