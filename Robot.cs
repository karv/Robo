namespace Robo
{
	/// A robot.
	public class Robot
	{
		/// Gets the attached componets of this robot.
		public RobotComponentColletion Componets { get; }

		/// 
		public Robot()
		{
			Componets = new RobotComponentColletion(this);
		}

	}
}