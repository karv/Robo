using System;
namespace Robo
{
	public abstract class CollisionRule<TMov, TStat> : ICollisionRule
	{
		public bool AreObjectsValid(ICollisionable movingObject, ICollisionable targetObject)
		{
			return movingObject is TMov && targetObject is TStat;
		}

		void ICollisionRule.OnCollision(ICollisionable movingObject, ICollisionable targetObject)
		{
			OnCollision((TMov)movingObject, (TStat)targetObject);
		}

		public abstract void OnCollision(TMov mov, TStat stat);
	}
	public class BeamToRobotCollisionRule : CollisionRule<Projectile, DeployedRobot>
	{
		public override void OnCollision(Projectile mov, DeployedRobot stat)
		{
			stat.Screen.RemoveWhenSafe(stat);
		}
	}
}
