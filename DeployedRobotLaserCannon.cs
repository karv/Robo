using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	public class DeployedRobotLaserCannon : IDeployedRobotComponent
	{
		public RobotLaserCannon Prototype { get; }
		public DeployedRobot Robot { get; }
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

		public float Fire(float maxEnergy)
		{
			var energyOutput = Math.Min(maxEnergy, Robot.Resources[ResourceType.Energy]);
			Robot.Resources[ResourceType.Energy] -= energyOutput;
			CreateAndFireBeam(energyOutput);
			return energyOutput;
		}

		IGameEntity CreateLaserBeam(float energy)
		{
			// create Beam class.
			// Initialize a new beam.
			throw new NotImplementedException();
		}

		void CreateAndFireBeam(float energy)
		{
			var beam = CreateLaserBeam(energy);
			// Add this beam to games entities.
			throw new NotImplementedException();
		}

		void Moggle.IDrawable.Draw(SpriteBatch batch)
		{
			var center = Prototype.RelativeUndeployedPosition + Robot.Position.TopLeft;
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