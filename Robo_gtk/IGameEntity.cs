using CE;

namespace Robo
{
	public interface IGameEntity
	{
		bool Visible { get; set; }
		Game Game { get; }
		void Draw(Painter painter);
		void Initialize();
	}
}
