namespace Robo
{
	/// A robot.
	public class Robot : GameEntity
	{
		/// Gets the attached componets of this robot.
		public RobotComponentColletion Componets { get; }

		/// 
		public Robot()
		{
			Componets = new RobotComponentColletion(this);
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
		{
			throw new System.NotImplementedException();
		}
	}
}