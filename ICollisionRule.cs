namespace Robo
{
	public interface ICollisionRule
	{
		bool AreObjectsValid(ICollisionable movingObject, ICollisionable targetObject);
		void OnCollision(ICollisionable movingObject, ICollisionable targetObject);
	}
}