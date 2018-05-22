using CE;
using Microsoft.Xna.Framework;
namespace Robo
{
	/// A component of a robot.
	public abstract class RobotComponent
	{
		/// Gets the robot owner.
		public Robot Owner { get; internal set; }
		public Vector2 RelativeUndeployedPosition { get; set; }
		//public Vector2 AbsolutePosition => RelativePosition + Owner. new PointF(RelativePosition.X + Owner.Position.Left, RelativePosition.Y + Owner.Position.Top);

		/// Detach this components from its robot.
		public void Detach() => Owner.Componets.Detach(this);
		/// Attach this components to the specified robot.
		public void Attach(Robot robot) => robot.Componets.Attach(this);
	}
}