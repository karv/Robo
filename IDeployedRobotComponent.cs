using Moggle;
using MonoGame.Extended;

namespace Robo
{
	public interface IDeployedRobotComponent : IDrawable, IUpdate
	{
		RobotComponent Prototype { get; }
		DeployedRobot Robot { get; }
	}
}