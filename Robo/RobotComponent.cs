using System;
using Microsoft.Xna.Framework;

namespace Robo
{
	/// A component of a robot.
	public abstract class RobotComponent : IRobotComponent
	{
		public string Name { get; }

		/// Gets the robot owner.
		public Robot Owner { get; private set; }

		public Vector2 RelativeUndeployedPosition { get; set; }
		//public Vector2 AbsolutePosition => RelativePosition + Owner. new PointF(RelativePosition.X + Owner.Position.Left, RelativePosition.Y + Owner.Position.Top);

		public RobotComponent(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Invalid name.", nameof(name));
			Name = name.Trim();
		}

		/// Attach this components to the specified robot.
		public void Attach(Robot robot)
		{
			if (robot is null) throw new ArgumentNullException(nameof(robot));

			if (Owner != null) throw new InvalidOperationException("Cannot attach an owned component.");

			Owner = robot;
			robot.Componets.Add(this);
		}

		public abstract IDeployedRobotComponent CreateDeploy(DeployedRobot robot);

		/// Detach this components from its robot.
		public void Detach()
		{
			if (Owner is null) throw new InvalidOperationException("Item already detached.");
			Owner.Componets.Remove(this);
		}
	}
}