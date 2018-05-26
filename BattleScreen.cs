using Moggle.Screens;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Robo
{
	public class BattleScreen : ListenerScreen
	{
		DeployedRobotLaserCannon _temporalCmp;
		public GameCamera Camera { get; private set; }
		public Battlefield Battlefield { get; }
		ICollection<IGameComponent> _removingComponents { get; } = new List<IGameComponent>();
		ICollection<IGameComponent> _addingComponents { get; } = new List<IGameComponent>();
		public BattleScreen(Moggle.Game game) : base(game)
		{
			ScreenViewport = new ScalingViewportAdapter(game.GraphicsDevice, 4000, 3000);
			Camera = new GameCamera(ScreenViewport);
			game.IsMouseVisible = true;
			Battlefield = new Battlefield(this);
			//AddComponent(Battlefield);
			AddComponent(new CollisionChecker(this));
		}

		// TODO: Move to Moggle
		public void RemoveWhenSafe(IGameComponent component)
		{
			_removingComponents.Add(component);
		}

		// TODO: Move to Moggle
		public void AddWhenSafe(IGameComponent component)
		{
			_addingComponents.Add(component);
		}

		public IGameEntity[] CloneEntities() => Components.OfType<IGameEntity>().ToArray();
		public ICollisionable[] CloneCollisionable() => Components.OfType<ICollisionable>().ToArray();
		protected override void DoInitialization()
		{
			base.DoInitialization();
			BatchOpts.Transformatrix = Camera.GetViewMatrix;
			KeyboardListener.KeyPressed += KeyboardListener_KeyPressed;

			DeployRobots();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			foreach (var cmpt in _addingComponents)
				AddComponent(cmpt);
			foreach (var cmpt in _removingComponents)
				DestroyComponents(cmpt);

			_addingComponents.Clear();
			_removingComponents.Clear();
		}

		void DeployRobots()
		{
			var robo = new Robot();
			var temporalCmp = new RobotLaserCannon("LR01");
			robo.Componets.Add(temporalCmp);
			var roboDeploy = new DeployedRobot(robo, this);
			_temporalCmp = (DeployedRobotLaserCannon)roboDeploy.GetComponent("LR01");

			roboDeploy.PutInBattlefield();

			_temporalCmp.AimReachedTarget += (sender, e) => Debug.WriteLine("Aim target reached.");

			new DeployedRobot(new Robot(), this).PutInBattlefield();
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

				// Temporal keys
				case Microsoft.Xna.Framework.Input.Keys.Up:
					_temporalCmp.TargetAim -= 1;
					break;
				case Microsoft.Xna.Framework.Input.Keys.Down:
					_temporalCmp.TargetAim += 1;
					break;
				case Microsoft.Xna.Framework.Input.Keys.Q:
					_temporalCmp.Fire();
					break;
			}
		}
	}
}