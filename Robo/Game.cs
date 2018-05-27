using Microsoft.Xna.Framework;

namespace Robo
{
	/// Main game class
	public class Game : Moggle.Game
	{
		/// Gets the collection of entities.
		public EntityCollection Entities { get; }

		public GraphicsDeviceManager Graphics { get; }

		///
		public Game()
		{
			Content.RootDirectory = "Content";
			Entities = new EntityCollection();
			Graphics = new GraphicsDeviceManager(this);
		}

		protected override void Initialize()
		{
			base.Initialize();
			var thr = Threads.CreateAndSwitch();
			var scr = new BattleScreen(this);
			thr.Stack(scr);
			thr.BackgroundColor = Color.Cyan;
			//var scr = thr.TopmostScreen;
		}

		/// Initialize all entities.
		protected void InitializeRegisteredEntities()
		{ foreach (var entity in Entities) entity.Initialize(); }

		public CollisionChecker CollitionChecker;
		public ObjectDisplacer Displacer;
	}
}