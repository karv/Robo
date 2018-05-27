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

		///
		public Game()
		{
			Content.RootDirectory = "Content";
			Entities = new EntityCollection();
			Graphics = new GraphicsDeviceManager(this);
		}

		protected override void LoadContent()
		{
			base.LoadContent();
			Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("laser pew");
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
	}
}