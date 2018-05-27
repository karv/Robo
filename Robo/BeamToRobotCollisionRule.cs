namespace Robo
{
	public class BeamToRobotCollisionRule : CollisionRule<Projectile, DeployedRobot>
	{
		public override void OnCollision(Projectile mov, DeployedRobot stat)
		{
			if (stat == mov.Origin) return;
			stat.Screen.RemoveWhenSafe(stat);
		}

		public readonly static BeamToRobotCollisionRule Rule = new BeamToRobotCollisionRule();
	}
}