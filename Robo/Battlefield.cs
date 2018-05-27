using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Robo
{
	public class Battlefield : Moggle.IDrawable, IGameComponent
	{
		public RectangleF BattleArea { get; }
		public Color FloorColor { get; set; } = Color.Brown;
		public float FloorHeight { get; } = 50;
		public List<DeployedRobot> Robots { get; }
		public BattleScreen Screen { get; }

		// Do not set because may mess the positions.
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

		public void Draw(SpriteBatch batch)
		{
			DrawBattlefield(batch);
			DrawFieldEntities(batch);
		}

		public void Initialize()
		{
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