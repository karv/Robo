using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;

namespace Robo
{
	public class Battlefield : Moggle.IDrawable, IGameComponent
	{
		public List<DeployedRobot> Robots { get; }
		public BattleScreen Screen { get; }
		public float FloorHeight { get; } = 50; // Do not set because may mess the positions.
		public Color FloorColor { get; set; } = Color.Brown;
		public RectangleF BattleArea { get; }
		public Battlefield(BattleScreen screen)
		{
			Screen = screen ?? throw new ArgumentNullException(nameof(screen));
			BattleArea = new RectangleF(0, 0, Screen.ScreenViewport.VirtualWidth, screen.ScreenViewport.VirtualHeight - FloorHeight);
			_floorRectangle = new RectangleF(
				0,
				Screen.ScreenViewport.VirtualHeight - FloorHeight,
				Screen.ScreenViewport.VirtualWidth,
				FloorHeight);

			Robots = new List<DeployedRobot>();
		}

		public void Initialize() { }
		public void Draw(SpriteBatch batch)
		{
			DrawBattlefield(batch);
			DrawFieldEntities(batch);
		}

		void DrawBattlefield(SpriteBatch batch)
		{
			batch.FillRectangle(_floorRectangle, FloorColor);
		}

		void DrawFieldEntities(SpriteBatch batch)
		{
			foreach (var dr in Robots)
				dr.Draw(batch);
		}

		readonly RectangleF _floorRectangle;
	}
}