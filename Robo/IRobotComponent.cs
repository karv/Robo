using Microsoft.Xna.Framework;

namespace Robo
{
	public interface IRobotComponent
	{
		string Name { get; }
		Robot Owner { get; }
		Vector2 RelativeUndeployedPosition { get; }

		void Attach(Robot robot);

		IDeployedRobotComponent CreateDeploy(DeployedRobot robot);

		void Detach();
	}
}