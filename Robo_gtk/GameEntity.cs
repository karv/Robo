namespace Robo
{
	/// Base class for common game entity : <see cref="IGameEntity"/>
	public abstract class GameEntity : IGameEntity
	{
		/// Gets the <see cref="Game"/>class.
		public Game Game { get; internal set; }
		/// Gets or sets the visibility status of this entity.
		public bool Visible
		{
			get => !_isInvisible;
			set => _isInvisible = !value;
		}

		/// Draw this entity using the specified <see cref="Painter"/>.
		public abstract void Draw(Painter painter);
		/// Initialize this object.
		public virtual void Initialize() { }

		bool _isInvisible;
	}
}
