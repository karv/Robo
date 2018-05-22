using Moggle.Screens;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;

namespace Robo
{
	public class BattleScreen : ListenerScreen
	{
		public GameCamera Camera { get; private set; }
		public Battlefield Battlefield { get; }
		public BattleScreen(Moggle.Game game) : base(game)
		{
			ScreenViewport = new ScalingViewportAdapter(game.GraphicsDevice, 4000, 3000);
			Camera = new GameCamera(ScreenViewport);
			game.IsMouseVisible = true;
			Battlefield = new Battlefield(this);
			AddComponent(Battlefield);
		}

		protected override void DoInitialization()
		{
			base.DoInitialization();
			BatchOpts.Transformatrix = Camera.GetViewMatrix;
			KeyboardListener.KeyPressed += KeyboardListener_KeyPressed;

			DeployRobots();
		}

		void DeployRobots()
		{
			var robo = new Robot();
			var roboDeploy = new DeployedRobot(robo, this);
			Battlefield.Robots.Add(roboDeploy);
		}

		void KeyboardListener_KeyPressed(object sender, KeyboardEventArgs e)
		{
			switch (e.Key)
			{
				case Microsoft.Xna.Framework.Input.Keys.Escape:
					Game.Exit();
					break;
				case Microsoft.Xna.Framework.Input.Keys.Enter:
					// Zoom 2x on first entity.
					Camera.LookAt(Battlefield.Robots[0].Position.Center);
					Camera.Zoom *= 1.1f;
					break;
				case Microsoft.Xna.Framework.Input.Keys.Space:
					Camera.Reset();
					break;
			}
		}
	}
}