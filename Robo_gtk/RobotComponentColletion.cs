using System;
using System.Collections.Generic;

namespace Robo
{
	public class RobotComponentColletion
	{
		public Robot Robot { get; }
		List<IRobotComponent> _pieces { get; }
		public RobotComponentColletion(Robot robot)
		{
			Robot = robot;
			_pieces = new List<IRobotComponent>();
		}

		public void Attach(IRobotComponent component)
		{
			if (component.Owner != null) throw new InvalidOperationException("Cannot attach an owned component.");

			component.Owner = Robot;
			_pieces.Add(component);
		}

		public void Detach(IRobotComponent component)
		{
			if (component is null) throw new ArgumentNullException(nameof(component));
			if (component.Owner is null) throw new InvalidOperationException("Item already detached.");

			if (component.Owner == Robot)
			{
				if (!_pieces.Remove(component))
					throw new Exception("Consistency error when trying to detach a component.");
			}
			else throw new InvalidOperationException("Cannot detach unowned component.");
		}
	}
}