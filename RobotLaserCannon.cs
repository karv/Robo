namespace Robo
{
	public class RobotLaserCannon : RobotComponent
	{
		public RobotLaserCannon(string name) : base(name)
		{
		}

		public override IDeployedRobotComponent CreateDeploy(DeployedRobot robot) => new DeployedRobotLaserCannon(robot, this);
	}
}