namespace Robo
{
	/// Main game class
	public class Game
	{
		/// Gets the collection of entities.
		public EntityCollection Entities { get; }

		/// Initialize.
		public void Initialize()
		{ InitializeRegisteredEntities(); }

		/// Initialize all entities in <see cref="Entities"/>.
		protected void InitializeRegisteredEntities()
		{ foreach (var entity in Entities) entity.Initialize(); }

		/// Initializes a new instance of the <see cref="Game"/> class.
		public Game()
		{ Entities = new EntityCollection(); }
	}
}
