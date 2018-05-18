using CE;

namespace Robo
{
	public abstract class GameEntity : IGameEntity
	{
		public Game Game { get; internal set; }
		public bool Visible { get; set; }

		public abstract void Draw(Painter painter);
		public virtual void Initialize(Game game) { }
	}
}
