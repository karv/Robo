using Microsoft.Xna.Framework;

namespace Robo
{
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
			var scr = new BattleScreen(this);
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