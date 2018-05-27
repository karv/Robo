using Microsoft.Xna.Framework.Audio;

namespace Robo
{
	public class RobotLaserCannon : RobotComponent
	{
		public SoundEffect FireSoundEffect;

		public RobotLaserCannon(string name) : base(name)
		{
			FireSoundEffect = Program.Game.Content.Load<SoundEffect>("laser pew");
		}

		public override IDeployedRobotComponent CreateDeploy(DeployedRobot robot) => new DeployedRobotLaserCannon(robot, this);
	}
}