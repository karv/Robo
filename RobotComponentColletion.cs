using System;
using System.Collections;
using System.Collections.Generic;

namespace Robo
{
	/// Collection of robot components.
	public class RobotComponentColletion : IReadOnlyCollection<RobotComponent>
	{
		/// Gets the robot associated to this collection.
		public Robot Robot { get; }
		public int Count => _pieces.Count;
		List<RobotComponent> _pieces { get; }

		/// Initializes a new instance of the <see cref="RobotComponentColletion"/> class.
		public RobotComponentColletion(Robot robot)
		{
			Robot = robot;
			_pieces = new List<RobotComponent>();
		}

		/// Attach the specified component.
		public void Attach(RobotComponent component)
		{
			if (component.Owner != null) throw new InvalidOperationException("Cannot attach an owned component.");

			component.Owner = Robot;
			_pieces.Add(component);
		}

		/// Detach the specified component.
		public void Detach(RobotComponent component)
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

		public IEnumerator<RobotComponent> GetEnumerator()
		{
			return ((IReadOnlyCollection<RobotComponent>)_pieces).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyCollection<RobotComponent>)_pieces).GetEnumerator();
		}
	}
}