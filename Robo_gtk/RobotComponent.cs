namespace Robo
{
	/// A component of a robot.
	public abstract class RobotComponent
	{
		/// Gets the robot owner.
		public Robot Owner { get; internal set; }

		/// Detach this components from its robot.
		public void Detach() => Owner.Componets.Detach(this);
		/// Attach this components to the specified robot.
		public void Attach(Robot robot) => robot.Componets.Attach(this);
	}
}