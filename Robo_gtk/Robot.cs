using CE;

namespace Robo
{
	public class Robot : GameEntity
	{
		RobotComponentColletion _components { get; }
		public Robot()
		{
			_components = new RobotComponentColletion(this);
		}

		public override void Draw(Painter painter)
		{
			throw new System.NotImplementedException();
		}
	}
}
