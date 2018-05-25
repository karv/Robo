using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Robo
{
	/// A robot during combat.
	public class DeployedRobot : GameEntity
	{
		public Color Color { get; set; }
		public Robot Robot { get; }
		public Battlefield Battlefield => Screen.Battlefield;
		public BattleScreen Screen { get; }
		public RobotResourceManager Resources { get; }
		List<IDeployedRobotComponent> _parts { get; }

		public DeployedRobot(Robot robot, BattleScreen screen)
		{
			Color = Color.Red;
			Screen = screen ?? throw new ArgumentNullException(nameof(screen));
			Robot = robot ?? throw new ArgumentNullException(nameof(robot));
			// TODO: No magic numbers.
			var topLeft = new Point2(RandomService.Rnd.NextSingle(0, Battlefield.BattleArea.Right), Battlefield.BattleArea.Bottom - Size.Height);
			Position = new RectangleF(topLeft, Size);

			Resources = new RobotResourceManager();

			// Generate the parts
			_parts = new List<IDeployedRobotComponent>(Robot.Componets.Count);
			foreach (var cmp in Robot.Componets)
			{
				var deploy = cmp.CreateDeploy(this);
				deploy.Initialize();
				_parts.Add(deploy);
			}

		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
		{
			batch.FillRectangle(Position, Color);
		}

		public static Size2 Size { get; }
		static DeployedRobot()
		{
			Size = new Size2(100, 50);
		}
	}
}