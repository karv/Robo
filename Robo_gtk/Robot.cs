﻿namespace Robo
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

		/// Draw this robot and all its components using the specified <see cref="Painter" />.
		public override void Draw(Painter painter)
		{
			throw new System.NotImplementedException();
		}
	}
}