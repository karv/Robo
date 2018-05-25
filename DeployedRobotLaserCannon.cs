using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System.Diagnostics;

namespace Robo
{
	public class DeployedRobotLaserCannon : IDeployedRobotComponent
	{
		public RobotLaserCannon Prototype { get; }
		public DeployedRobot Robot { get; }
		public Vector2 Center => Prototype.RelativeUndeployedPosition + Robot.Position.TopLeft;
		public float CurrentAim { get; private set; }
		public float TargetAim { get; set; } // TODO: Force value between -pi and pi

		public bool AimOnTarget
		{
			get => _aimOnTarget;
			private set
			{
				if (_aimOnTarget == value) return;
				_aimOnTarget = value;
				if (value) AimReachedTarget?.Invoke(this, EventArgs.Empty);
			}
		}

		RobotComponent IDeployedRobotComponent.Prototype => Prototype;

		public DeployedRobotLaserCannon(DeployedRobot robot, RobotLaserCannon prototype)
		{
			Robot = robot ?? throw new ArgumentNullException(nameof(robot));
			Prototype = prototype ?? throw new ArgumentNullException(nameof(prototype));
		}

		public float Fire()
		{
			var energyOutput = Robot.Resources[ResourceType.Energy];
			Robot.Resources[ResourceType.Energy] = 0;
			CreateAndFireBeam(energyOutput);
			return energyOutput;
		}

		public float Fire(float maxEnergy)
		{
			var energyOutput = Math.Min(maxEnergy, Robot.Resources[ResourceType.Energy]);
			Robot.Resources[ResourceType.Energy] -= energyOutput;
			CreateAndFireBeam(energyOutput);
			return energyOutput;
		}

		SlowLaserBeam CreateLaserBeam(float energy)
		{
			var ret = new SlowLaserBeam(Robot.Screen)
			{
				Energy = energy,
				EnergyLoseRatio = 0.5f,
				Direction = new Vector2((float)Math.Cos(CurrentAim), (float)Math.Sin(CurrentAim)),
				Velocity = 400,
				Position = Center
			};
			ret.Discipated += (sender, e) => Debug.WriteLine("Beam discipated");
			ret.Initialize();
			return ret;
		}

		void CreateAndFireBeam(float energy)
		{
			var beam = CreateLaserBeam(energy);
			beam.AddToBattlefield();
		}

		void Moggle.IDrawable.Draw(SpriteBatch batch)
		{
			var center = Center;
			batch.DrawCircle(center, Radius, Sides, Color, Thickness);
			batch.DrawLine(center, AimLength, CurrentAim, Color, Thickness);
		}

		void IGameComponent.Initialize()
		{
			CurrentAim = TargetAim;
			AimOnTarget = true;
		}

		void IUpdate.Update(GameTime gameTime)
		{
			var maxAimDelta = (float)gameTime.ElapsedGameTime.TotalSeconds * AimRotationSpeed;
			AimOnTarget = Math.Abs(TargetAim - CurrentAim) < maxAimDelta;
			if (!AimOnTarget)
				// Check for best direction (use S_1 metric)
				CurrentAim += TargetAim > CurrentAim ? maxAimDelta : -maxAimDelta;
			ResetEnergy();
		}

		[Conditional("DEBUG")]
		void ResetEnergy(float newEnergy = 1)
		{
			Robot.Resources[ResourceType.Energy] = newEnergy;
		}

		/// Occurs when aim reached its target rotation.
		public event EventHandler AimReachedTarget;
		bool _aimOnTarget;

		public const float Radius = 30;
		public const float AimLength = 40;
		public const int Sides = 10;
		public const int Thickness = 10;
		public const float AimRotationSpeed = 1f;

		public static Color Color => Color.DarkBlue;
	}
}