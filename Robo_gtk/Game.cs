namespace Robo
{
	public class Game
	{
		public Painter Painter { get; }
		public EntityCollection _entities { get; }

		public void Initialize()
		{ InitializeRegisteredEntities(); }

		protected void InitializeRegisteredEntities()
		{ foreach (var entity in _entities) entity.Initialize(this); }

		public Game()
		{
			Painter = new Painter();
			_entities = new EntityCollection();
		}
	}
}
