namespace Robo
{
	public interface IDeployedRobotComponent : Moggle.IDrawable
	{
		RobotComponent Prototype { get; }
		DeployedRobot Robot { get; }
	}
}