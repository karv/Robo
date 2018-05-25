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
			batch.DrawCircle(Prototype.RelativeUndeployedPosition, Radius, Sides, Color);
		}

		void IGameComponent.Initialize() { }

		public const float Radius = 10;
		public const int Sides = 10;
		public static Color Color { get; } = Color.Red;
	}
}