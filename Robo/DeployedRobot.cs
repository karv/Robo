using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Robo
{
	/// A robot during combat.
	public class DeployedRobot : GameEntity, ICollisionable
	{
		public static Size2 Size { get; }
		public Color Color { get; set; }
		public RobotResourceManager Resources { get; }
		public Robot Robot { get; }
		public BattleScreen Screen { get; }
		public Battlefield Battlefield => Screen.Battlefield;
		List<IDeployedRobotComponent> _parts { get; }

		static DeployedRobot()
		{
			Size = new Size2(100, 50);
		}

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
				_parts.Add(deploy);
			}
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
		{
			batch.FillRectangle(Position, Color);
		}

		public IDeployedRobotComponent GetComponent(string id)
		{
			// TODO: existence check.
			return _parts.First(z => string.Equals(z.Prototype.Name, id, StringComparison.InvariantCultureIgnoreCase));
		}

		public override void Initialize()
		{ foreach (var c in _parts) c.Initialize(); }

		/// Adds this robot into the battlefield, initializes all the required components, and add it
		/// into the screen draw and update list.
		public void PutInBattlefield()
		{
			//Initialize();
			Screen.AddComponent(this);
			foreach (var c in _parts) Screen.AddComponent(c);

			Battlefield.Robots.Add(this);
		}

		bool ICollisionable.ExistCollisionWith(ICollisionable other) => true;

		RectangleF ICollisionable.GetCollisionRectangle() => Position;

		// Always collision in my box.
	}
}