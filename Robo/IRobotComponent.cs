using Microsoft.Xna.Framework;

namespace Robo
{
	public interface IRobotComponent
	{
		Robot Owner { get; }
		string Name { get; }
		Vector2 RelativeUndeployedPosition { get; }

		void Detach();

		void Attach(Robot robot);

		IDeployedRobotComponent CreateDeploy(DeployedRobot robot);
	}
}