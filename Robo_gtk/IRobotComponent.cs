namespace Robo
{
	public interface IRobotComponent
	{
		Robot Owner { get; set; }
	}

	public abstract class RobotComponent : IRobotComponent
	{
		public Robot Owner { get; set; }
	}
}