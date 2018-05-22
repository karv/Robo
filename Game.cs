using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Moggle.Controls;
using Moggle.Screens;
using MonoGame.Extended;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;

namespace Robo
{
	public class LineControl : ClickableControl, Moggle.IDrawable
	{
		protected override Rectangle Bounds => _bounds;

		public LineControl(MouseListener mouse) : base(mouse) { }

		protected override void OnClick(ControlMouseEventArgs e)
		{
			Debug.WriteLine("clicked.");
		}
		void Moggle.IDrawable.Draw(SpriteBatch batch)
		{
			batch.DrawLine(_bounds.Left, _bounds.Top, _bounds.Right, _bounds.Bottom, Color.Green, 10);
			batch.DrawCircle(_bounds.Right, _bounds.Bottom, 200, 100, Color.Blue, 5);
			batch.DrawPoint(_bounds.Center.ToVector2(), Color.White * 1f, 20);
		}

		readonly Rectangle _bounds = new Rectangle(0, 0, 1000, 1000);
	}

	public class MainScreen : ListenerScreen
	{
		public MainScreen(Moggle.Game game) : base(game)
		{
			ScreenViewport = new ScalingViewportAdapter(game.GraphicsDevice, 4000, 3000);
			game.IsMouseVisible = true;
		}

		protected override void DoInitialization()
		{
			base.DoInitialization();
			var ln = new LineControl(MouseListener);
			AddComponent(ln);
			KeyboardListener.KeyPressed += KeyboardListener_KeyPressed;
		}

		void KeyboardListener_KeyPressed(object sender, MonoGame.Extended.Input.InputListeners.KeyboardEventArgs e)
		{
			if (e.Key == Microsoft.Xna.Framework.Input.Keys.Escape)
				Game.Exit();
		}
	}

	/// Main game class
	public class Game : Moggle.Game
	{
		public GraphicsDeviceManager Graphics { get; }
		public CollisionChecker CollitionChecker;
		public ObjectDisplacer Displacer;

		/// Gets the collection of entities.
		public EntityCollection Entities { get; }

		protected override void Initialize()
		{
			base.Initialize();
			var thr = Threads.CreateAndSwitch();
			var scr = new MainScreen(this);
			thr.Stack(scr);
			thr.BackgroundColor = Color.Cyan;
			//var scr = thr.TopmostScreen;
		}

		/// Initialize all entities in <see cref="Entities"/>.
		protected void InitializeRegisteredEntities()
		{ foreach (var entity in Entities) entity.Initialize(); }

		/// Initializes a new instance of the <see cref="Game"/> class.
		public Game()
		{
			Entities = new EntityCollection();
			Graphics = new GraphicsDeviceManager(this);
		}
	}
}