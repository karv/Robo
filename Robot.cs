using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;
using Moggle;

namespace Robo
{
	public class Battlefield : Moggle.IDrawable, IGameComponent
	{
		public ICollection<DeployedRobot> Robots { get; }
		public BattleScreen Game { get; }
		public float FloorHeight { get; } = 50; // Do not set because may mess the positions.
		public Color FloorColor { get; set; } = Color.Brown;
		public Battlefield(BattleScreen screen)
		{
			Game = screen ?? throw new ArgumentNullException(nameof(screen));
		}

		public void DrawBattlefield(SpriteBatch batch)
		{
			var floorRectangle = new RectangleF(
				0,
				Game.ScreenViewport.VirtualHeight - FloorHeight,
				Game.ScreenViewport.VirtualWidth,
				FloorHeight);
			batch.FillRectangle(floorRectangle, FloorColor);
		}

		public void Draw(SpriteBatch batch)
		{
			DrawBattlefield(batch);
		}

		public void Initialize()
		{
		}
	}
	/// A robot during combat.
	public class DeployedRobot : GameEntity
	{
		public Color Color { get; set; }
		public Robot Robot { get; }

		public DeployedRobot(Robot robot)
		{
			Color = Color.Red;
			Robot = robot ?? throw new ArgumentNullException(nameof(robot));
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
		{
			batch.FillRectangle(Position, Color);
		}
	}
	/// A robot.
	public class Robot
	{
		/// Gets the attached componets of this robot.
		public RobotComponentColletion Componets { get; }

		/// 
		public Robot()
		{
			Componets = new RobotComponentColletion(this);
		}

	}
}